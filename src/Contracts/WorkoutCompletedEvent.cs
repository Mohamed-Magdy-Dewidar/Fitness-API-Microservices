
namespace Contracts;
public record WorkoutCompletedEvent
{
    public required Guid LogId { get; init; }
    public required string UserId { get; init; }
    public required Guid WorkoutId { get; init; }
    public required string WorkoutName { get; init; }
    public required string SessionId { get; init; }
    public  required DateTime CompletedAtUtc { get; init; }
    public required  int DurationMinutes { get; init; }
    public  required int CaloriesBurned { get; init; }


    // Type-specific details (nullable)
    public int? Sets { get; init; }
    public int? Reps { get; init; }
    public double? Distance { get; init; }
    public string? DistanceUnit { get; init; }
}
