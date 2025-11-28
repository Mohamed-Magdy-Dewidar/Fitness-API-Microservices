namespace ProgressTrackingService.Entities;


public class TimedLog : WorkoutLog
{
    public int HoldTimeSeconds { get; set; }
    public int Rounds { get; set; }
    public int RestTimeSeconds { get; set; }
    public TimedLog() { LogType = "Timed"; }
}