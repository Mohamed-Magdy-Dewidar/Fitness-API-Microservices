using Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkOutService.Entities;


public class Workout : BaseEntity<Guid>
{

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Category { get; set; } = string.Empty; // "full-body", "upper", "lower", "cardio"

    [Required]
    [StringLength(50)]
    public string Difficulty { get; set; } = string.Empty; // "Beginner", "Intermediate", "Advanced"

    public int DurationMinutes { get; set; }
    public int EstimatedCaloriesBurn { get; set; }

    // Media
    public string? ImageUrl { get; set; }
   
    

    // Metadata
    [StringLength(500)]
    public string Tags { get; set; } = string.Empty; // "hiit,cardio,fat-loss,home-workout"

    

    // Engagement Metrics
    public double AverageRating { get; set; } = 0.0;
    public int TotalRatings { get; set; } = 0;

    // Navigation Properties
    public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();    


}

