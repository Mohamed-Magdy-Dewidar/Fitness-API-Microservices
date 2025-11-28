using Contracts;
using FluentValidation;
using MassTransit;
using MediatR;
using ProgressTrackingService.Contracts.ProgressTracking;
using ProgressTrackingService.Database;
using ProgressTrackingService.Entities;
using ProgressTrackingService.Shared.MarkerInterface;
using Shared;
using StackExchange.Redis;
using System.Text.Json.Serialization;

namespace ProgressTrackingService.Features.ProgressTracking.SubmittWorkOut;

public static class SubmitWorkoutOrchestrator
{
    public record Command : ICommand<Result<LogWorkoutResponse>>
    {

        [JsonIgnore]
        public required string UserId { get; set; } = default!;

        public required string SessionId { get; init; }
        public required DateTime CompletedAtUtc { get; init; }
        public required int ActualDurationMinutes { get; init; }
        public required int CaloriesBurned { get; init; }
        public string? Notes { get; init; }
        public required List<ExercisePerformanceDto> PerformanceData { get; init; }
    }

    public record ExercisePerformanceDto
    {
        public required Guid ExerciseId { get; init; }
        public string? LogType { get; init; }
        public int? SetsCompleted { get; init; }
        public int? RepsCompleted { get; init; }
        public decimal? WeightLifted { get; init; }
        public decimal? Distance { get; init; }
        public string? DistanceUnit { get; init; }
        public int? TimeUnderTensionSeconds { get; init; }
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ActualDurationMinutes).GreaterThan(0);
            RuleFor(x => x.CaloriesBurned).GreaterThanOrEqualTo(0);
            RuleForEach(x => x.PerformanceData).SetValidator(new ExercisePerformanceValidator());
        }
    }

    public class ExercisePerformanceValidator : AbstractValidator<ExercisePerformanceDto>
    {
        public ExercisePerformanceValidator()
        {
            RuleFor(x => x.ExerciseId).NotEmpty();
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Result<LogWorkoutResponse>>
    {
        private readonly Repository<ActiveSession, string> _activeSessionsRepository;
        private readonly Repository<WorkoutLog, Guid> _workoutLogRepo;
        private readonly IValidator<Command> _validator;
        private readonly IConnectionMultiplexer _redis;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<Handler> _logger;

        public Handler(
            Repository<ActiveSession, string> activeSessions,
            Repository<WorkoutLog, Guid> workoutLogRepo,
            IValidator<Command> validator,
            IConnectionMultiplexer connectionMultiplexer,
            IPublishEndpoint publishEndpoint,
            ILogger<Handler> logger)
        {
            _activeSessionsRepository = activeSessions;
            _validator = validator;
            _redis = connectionMultiplexer;
            _publishEndpoint = publishEndpoint;
            _workoutLogRepo = workoutLogRepo;
            _logger = logger;
        }

        public async Task<Result<LogWorkoutResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                var errors = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
                return Result.Failure<LogWorkoutResponse>(
                    new Error("VALIDATION_ERROR", errors)
                );
            }

            var redisDb = _redis.GetDatabase();
            var redisKey = $"workout_session:{request.SessionId}:user:{request.UserId}";

            if (!await redisDb.KeyExistsAsync(redisKey))
            {
                return Result.Failure<LogWorkoutResponse>(
                    new Error("SESSION_EXPIRED", "Workout session not found in Redis.")
                );
            }

            var activeSession = await _activeSessionsRepository.GetByIdAsync(request.SessionId, trackChanges: true);

            if (activeSession == null)
            {
                await redisDb.KeyDeleteAsync(redisKey); 
                return Result.Failure<LogWorkoutResponse>(
                    new Error("SESSION_MISMATCH", "Redis session exists but SQL session is missing.")
                );
            }

            try
            {
                activeSession.Status = ActivityStatus.Completed;
                activeSession.CompletedAtUtc = request.CompletedAtUtc;
                activeSession.IsAbandoned = false;

                var mainLogId = Guid.NewGuid();


                foreach (var perf in request.PerformanceData)
                {
                    WorkoutLog logEntry = CreateSpecificLogEntry(mainLogId, activeSession, perf, request);
                    await _workoutLogRepo.AddAsync(logEntry);
                }


                //_activeSessionsRepository.SaveInclude(activeSession , [nameof(activeSession.CompletedAtUtc) , nameof(activeSession.Status) , nameof(activeSession.IsAbandoned)]);
                _activeSessionsRepository.Update(activeSession);


                // will be called in the Transaction MiddleWare
                //await _activeSessionsRepository.SaveChangesAsync(cancellationToken);

                await redisDb.KeyDeleteAsync(redisKey);

                var evt = new WorkoutCompletedEvent
                {
                    LogId = mainLogId,
                    UserId = request.UserId,
                    SessionId = request.SessionId,
                    WorkoutId = activeSession.WorkoutId,
                    WorkoutName = activeSession.WorkoutName,
                    CompletedAtUtc = request.CompletedAtUtc,
                    DurationMinutes = request.ActualDurationMinutes,
                    CaloriesBurned = request.CaloriesBurned                    
                };

                await _publishEndpoint.Publish(evt, cancellationToken);
                

                _logger.LogInformation("Workout logged successfully: LogId={LogId}", mainLogId);
                return Result.Success<LogWorkoutResponse>(new LogWorkoutResponse(mainLogId, request.SessionId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Workout logging failed for SessionId={SessionId}", request.SessionId);

                return Result.Failure<LogWorkoutResponse>(
                    new Error("DATABASE_ERROR", "Failed to finalize workout log.")
                );
            }

            
        }



        private WorkoutLog CreateSpecificLogEntry(
            Guid mainLogId,
            ActiveSession session,
            ExercisePerformanceDto perf,
            Command request)
        {
            WorkoutLog log = perf.LogType switch
            {
                "Weight" => new WeightLog
                {
                    Sets = perf.SetsCompleted ?? 0,
                    Reps = perf.RepsCompleted ?? 0,
                    WeightLifted = perf.WeightLifted ?? 0,
                },
                "Cardio" => new CardioLog
                {
                    Distance = perf.Distance ?? 0,
                    DistanceUnit = perf.DistanceUnit,
                },
                "Timed" => new TimedLog
                {
                    HoldTimeSeconds = perf.TimeUnderTensionSeconds ?? 0
                },
                _ => throw new InvalidOperationException($"Invalid log type: {perf.LogType}")
            };

            log.Id = mainLogId;
            log.UserId = request.UserId;
            log.WorkoutId = session.WorkoutId;
            log.SessionId = session.Id;
            log.CompletedAtUtc = request.CompletedAtUtc;
            log.DurationMinutes = request.ActualDurationMinutes;
            log.CaloriesBurned = request.CaloriesBurned;
            log.Notes = request.Notes;

            return log;
        }
    }
}
