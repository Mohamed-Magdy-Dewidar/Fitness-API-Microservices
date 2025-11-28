using ProgressTrackingService.Entities;

public class CardioLog : WorkoutLog
{
    public CardioLog() { LogType = "Cardio"; }

    public decimal? Distance { get; set; } 

    public string? DistanceUnit { get; set; }

    public int? AverageHeartRate { get; set; }
    public decimal? AveragePace { get; set; } 
    public decimal? MaxSpeed { get; set; }    

}