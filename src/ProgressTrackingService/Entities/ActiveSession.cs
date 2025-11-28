using Shared;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProgressTrackingService.Entities;



public class ActiveSession : BaseEntity<string>
{
    public string UserId { get; set; } = string.Empty;
    public Guid WorkoutId { get; set; }

    public string WorkoutName { get; set; } = string.Empty;
    public DateTime StartedAtUtc { get; set; } = DateTime.UtcNow;
    

    public required int PlannedDurationMinutes { get; init; }
    
    public required string DifficultyLevel { get; init; }

    public string Status { get; set; } = ActivityStatus.InProgress; 

    public string? SessionData { get; set; } // JSON serialized state
    public bool IsAbandoned { get; set; } = false;


    [NotMapped]
    public bool DeadlineExceeded => DateTime.UtcNow > StartedAtUtc.AddMinutes(PlannedDurationMinutes);

   public DateTime? CompletedAtUtc { get; set; }

}
