using Shared;
using System.ComponentModel.DataAnnotations;


namespace WorkOutService.Entities;
public class Exercise : BaseEntity<Guid>
{
    
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Instructions { get; set; } // Detailed how-to

    public string TargetMuscleGroup { get; set; } = string.Empty; // "Chest", "Legs", "Back", "Core"

    [StringLength(50)]
    public string Difficulty { get; set; } = DifficultyLevels.Beginner; // Exercise-level difficulty

    public int EstimatedCaloriesPerRep { get; set; } = 0; // For calculation

    // Media
    public string? VideoUrl { get; set; }

    public string? ImageUrl { get; set; }

    // Navigation Property
    public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}

    