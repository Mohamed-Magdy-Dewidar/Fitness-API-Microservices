
namespace WorkOutService.Entities;

public class WorkoutExercise
{
    // Composite Primary Key: WorkoutId + ExerciseId
    public Guid WorkoutId { get; set; }
    public Guid ExerciseId { get; set; }



    public int Order { get; set; } // To keep exercises in the correct sequence (1, 2, 3...)

    public int Sets { get; set; }

   
    public string Reps { get; set; } // String to allow "12-15" or "30 seconds"

    public int RestTimeSeconds { get; set; }

    public string? Instructions { get; set; } 
    public virtual Workout Workout { get; set; }
    public virtual Exercise Exercise { get; set; }
}


