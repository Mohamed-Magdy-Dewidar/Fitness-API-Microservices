using Contracts; 
using FluentValidation;
using MassTransit;
using MediatR;
using Shared;
using WorkOutService.Contracts;
using WorkOutService.Database;
using WorkOutService.Entities;
using WorkOutService.Services;

namespace WorkOutService.Features.WorkOut;

public static class StartWorkOutSession
{

    public record Command(Guid WorkoutId, string UserId) : IRequest<Result<StartWorkOutSessionResponse>>;

    
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.WorkoutId).NotEmpty().WithMessage("WorkoutId is required.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Result<StartWorkOutSessionResponse>>
    {
        private readonly Repository<Workout, Guid> _workOutRepository;
        private readonly IWorkOutCacheService _cacheService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IValidator<Command> _validator;
        private readonly ILogger<Handler> _logger; // Added logger for detailed logs

        public Handler(Repository<Workout, Guid> workOutRepository,IWorkOutCacheService cacheService,IPublishEndpoint publishEndpoint,IValidator<Command> validator,ILogger<Handler> logger) 
        {
            _workOutRepository = workOutRepository;
            _cacheService = cacheService;
            _publishEndpoint = publishEndpoint;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<StartWorkOutSessionResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("Validation failed for StartWorkOutSession: {Errors}", errors);
                return Result.Failure<StartWorkOutSessionResponse>(new Error("Validation.Error", string.Join(" | ", errors)));
            }

            var workout = await _workOutRepository.GetByIdAsync(request.WorkoutId);
            if (workout == null)
            {
                _logger.LogWarning("Attempt to start non-existent workout ID: {WorkoutId}", request.WorkoutId);
                return Result.Failure<StartWorkOutSessionResponse>(new Error("Workout.Not.Found", $"The workout with Id {request.WorkoutId} was not Found"));
            }

            var sessionId = _cacheService.GetWorkOutSessionKey(Guid.NewGuid());
            var startedAtUtc = DateTime.UtcNow;
            var deadlineUtc = startedAtUtc.AddMinutes(workout.DurationMinutes);
            var expiryTimeSpan = TimeSpan.FromMinutes(workout.DurationMinutes + 10); // 10 min grace period

            try
            {
                await _cacheService.CreateWorkOutSessionCacheAsync(sessionId,request.UserId,request.WorkoutId,startedAtUtc,ActivityStatus.InProgress, deadlineUtc,expiryTimeSpan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Redis cache for session {SessionId}.", sessionId);
                return Result.Failure<StartWorkOutSessionResponse>(new Error("SRV_INTERNAL_ERROR", "Failed to cache session data."));
            }

            await _publishEndpoint.Publish(new WorkoutSessionStartedEvent
            {
                SessionId = sessionId,
                WorkoutId = request.WorkoutId,
                UserId = request.UserId,
                PlannedDurationMinutes = workout.DurationMinutes,
                DifficultyLevel = workout.Difficulty,
                StartedAtUtc = startedAtUtc,
                DeadlineUtc = deadlineUtc
            }, cancellationToken);


            var response = new StartWorkOutSessionResponse(sessionId, startedAtUtc, deadlineUtc);
            _logger.LogInformation("Successfully started and published session {SessionId}.", sessionId);

            return Result.Success(response);
        }
    }
}