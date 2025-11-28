using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.Contracts.ProgressTracking;
using ProgressTrackingService.Database;
using ProgressTrackingService.Entities;
using ProgressTrackingService.Shared.MarkerInterface;
using Shared;
using StackExchange.Redis;

namespace ProgressTrackingService.Features.ProgressTracking.AbortSession
{
    public static class AbortActiveSessionOrchestrator
    {
        public record Command(string UserId , Guid SessionId) : ICommand<Result<SuccessResponse>>;
       

        

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.UserId).NotEmpty();
                RuleFor(x => x.SessionId).NotEmpty();
            }
        }

        internal sealed class Handler : IRequestHandler<Command, Result<SuccessResponse>>
        {
            private readonly Repository<ActiveSession, string> _sessionRepository;
            private readonly IConnectionMultiplexer _redisConnection;
            private readonly IValidator<Command> _validator;

            public Handler(Repository<ActiveSession, string> sessionRepository,IConnectionMultiplexer redisConnection,IValidator<Command> validator)
            {
                _sessionRepository = sessionRepository;
                _redisConnection = redisConnection;
                _validator = validator;
            }

            public async Task<Result<SuccessResponse>> Handle(Command request,CancellationToken cancellationToken)
            {

                var validation = await _validator.ValidateAsync(request, cancellationToken);
                if (!validation.IsValid)
                {
                    var errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
                    return Result.Failure<SuccessResponse>(new Error("RES_VALIDATION_FAILED", errors.ToString()));
                }

                var redis = _redisConnection.GetDatabase();
                string redisKey = $"workout_session:{request.SessionId}:user:{request.UserId}";


                var session = await _sessionRepository
                    .FindByCondition(s => s.Id.Equals(request.SessionId) && s.UserId.Equals(request.UserId) ,  trackChanges: false)
                    .FirstOrDefaultAsync(cancellationToken);                    
                    

                if (session is null)
                {
                    // Clean any stale Redis key
                    if (await redis.KeyExistsAsync(redisKey))
                        await redis.KeyDeleteAsync(redisKey);
                    return Result.Failure<SuccessResponse>( new Error("RES_SESSION_NOT_FOUND", "Active session not found."));
                }

                session.Status = ActivityStatus.Canceled;
                session.IsAbandoned = true;
                session.CompletedAtUtc = null;
                session.UpdatedOnUtc = DateTime.UtcNow;

                await redis.KeyDeleteAsync(redisKey);


                 string[] DesiredValuesTobeUpdated = 
                    [nameof(session.Status), nameof(session.IsAbandoned), nameof(session.CompletedAtUtc), nameof(session.UpdatedOnUtc)];
                 _sessionRepository.SaveInclude(session,DesiredValuesTobeUpdated);

                return Result.Success(new SuccessResponse(
                    session.Id,
                    session.Status.ToString()
                ));
            }
        }
    }
}
