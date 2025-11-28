using Shared;
using System.ComponentModel.DataAnnotations;
namespace ProgressTrackingService.Entities;



public abstract class WorkoutLog : BaseEntity<Guid>
{
    public string UserId { get; set; } = string.Empty;
    public Guid WorkoutId { get; set; }

    public string WorkoutName { get; set; } = string.Empty;
    public string SessionId { get; set; } 
    public DateTime CompletedAtUtc { get; set; } = DateTime.UtcNow;
    public int DurationMinutes { get; set; }
    public int CaloriesBurned { get; set; }

    public string? Notes { get; set; }

    // Discriminator for TPH pattern (configured in DbContext)
    public string LogType { get; set; } = string.Empty; // "Weight", "Cardio", "Timed"
}







