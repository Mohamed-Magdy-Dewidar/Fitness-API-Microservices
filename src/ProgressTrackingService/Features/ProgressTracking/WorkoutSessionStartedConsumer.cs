using Contracts;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.DataBase;
using ProgressTrackingService.Entities;
using Shared;
using StackExchange.Redis;

namespace ProgressTrackingService.Features.WorkOut;

public class WorkoutSessionStartedConsumer : IConsumer<WorkoutSessionStartedEvent>
{
    private readonly ProgressTrackingDbContext _context;
    private readonly ILogger<WorkoutSessionStartedConsumer> _logger;
    private readonly IDatabase _redis;

    public WorkoutSessionStartedConsumer(ProgressTrackingDbContext context, IConnectionMultiplexer connectionMultiplexer ,   ILogger<WorkoutSessionStartedConsumer> logger)
    {
        _context = context;
        _redis = connectionMultiplexer.GetDatabase();
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<WorkoutSessionStartedEvent> context)
    {
        var message = context.Message;

        try
        {
            var existingSession = await _context.ActiveSessions
                .FirstOrDefaultAsync(s => s.Id == message.SessionId, context.CancellationToken);

            if (existingSession is not null)
            {
                _logger.LogWarning("ActiveSession {SessionId} already exists in DB. Ignoring duplicate event.", message.SessionId);
                return;
            }


            var hashEntries = await _redis.HashGetAllAsync(message.SessionId);
            if( hashEntries is null || hashEntries.Length == 0)
                _logger.LogWarning("No session data found in Redis for SessionId={SessionId}. Proceeding with null SessionData.", message.SessionId);

            var sessionData = System.Text.Json.JsonSerializer.Serialize(hashEntries.ToDictionary());

            var activeSession = new ActiveSession
            {
                Id = message.SessionId,
                UserId = message.UserId,
                WorkoutId = message.WorkoutId,
                StartedAtUtc = message.StartedAtUtc,
                Status = ActivityStatus.InProgress,
                PlannedDurationMinutes = message.PlannedDurationMinutes,
                DifficultyLevel = message.DifficultyLevel,
                SessionData = sessionData ,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow
            };

            _context.ActiveSessions.Add(activeSession);
            await _context.SaveChangesAsync(context.CancellationToken);

            _logger.LogInformation(" ActiveSession successfully logged: SessionId={SessionId}, UserId={UserId}", message.SessionId, message.UserId);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex,
                "DB concurrency error during session creation for {SessionId}. Retrying via MassTransit.",
                message.SessionId);
            throw; // Must re-throw to trigger MassTransit's retry policy
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Failed to process WorkoutSessionStartedEvent for {SessionId}.",
                message.SessionId);
            throw; // Will trigger MassTransit retry policy
        }
    }
}