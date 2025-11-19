namespace WorkOutService.Contracts;


/// <summary>
/// Represents a single exercise step within a workout plan.
/// Maps data from Exercise + WorkoutExercise join table.
/// </summary>
public record ExerciseDetailDto(
    Guid Id,
    string Name,
    int Order, // The sequence number
    int Sets,
    string Reps, // "12-15" or "30 seconds"
    int RestTimeSeconds,
    string Instructions,
    string TargetMuscleGroup,
    string? VideoUrl
);

/// <summary>
/// The root response for GET /api/v1/workouts/{id}.
/// </summary>
public record GetWorkOutDetailsResponse(
    Guid Id,
    string Name,
    string Description,
    string Category,
    string Difficulty,
    int DurationMinutes,
    int EstimatedCaloriesBurn,
    string? ImageUrl,
    double AverageRating,
    int TotalRatings,
    IEnumerable<ExerciseDetailDto> Exercises 
);