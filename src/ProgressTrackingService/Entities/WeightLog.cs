using ProgressTrackingService.Entities;

public class WeightLog : WorkoutLog
{
    public WeightLog() { LogType = "Weight"; }

    public int Sets { get; set; }
    
    public int Reps { get; set; }
    
    public decimal? WeightLifted { get; set; } 
    
    public string? Exercises { get; set; } 


}