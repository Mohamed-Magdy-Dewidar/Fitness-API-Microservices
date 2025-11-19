namespace WorkOutService.Contracts;

public record StartWorkOutSessionResponse(string SessionId, DateTime StartedAtUtc, DateTime DeadlineUtc);
