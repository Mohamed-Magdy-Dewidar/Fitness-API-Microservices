namespace WorkOutService.Services;




public interface IWorkOutCacheService
{
    public string GetWorkOutSessionKey(Guid sessionId);
    Task CreateWorkOutSessionCacheAsync(string sessionId,string userId,Guid workoutId,DateTime startedAtUtc,string status,DateTime deadlineUtc,TimeSpan expiry);
}