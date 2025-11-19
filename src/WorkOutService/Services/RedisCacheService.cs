
using StackExchange.Redis;

namespace WorkOutService.Services;


public class RedisCacheService(IConnectionMultiplexer connectionMultiplexer) : IWorkOutCacheService
{
    private readonly IDatabase _redis = connectionMultiplexer.GetDatabase();

    public string GetWorkOutSessionKey(Guid sessionId) => $"workout_session:{sessionId}";


    public async Task CreateWorkOutSessionCacheAsync(string sessionId,string userId,Guid workoutId,DateTime startedAtUtc,string status,DateTime deadlineUtc,TimeSpan expiry)
    {
        
        var workOutSessionData = new HashEntry[]
        {
                new HashEntry("sessionId", sessionId.ToString()),
                new HashEntry("userId", userId),
                new HashEntry("workoutId", workoutId.ToString()),
                new HashEntry("startedAtUtc", startedAtUtc.ToString("o")), 
                new HashEntry("status", status),
                new HashEntry("deadlineUtc", deadlineUtc.ToString("o"))
        };

        await _redis.HashSetAsync(sessionId, workOutSessionData);
        await _redis.KeyExpireAsync(sessionId, expiry);
    }

}

