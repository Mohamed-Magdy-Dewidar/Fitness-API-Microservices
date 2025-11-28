namespace ProgressTrackingService.Contracts;


public interface IDbIntializer
{
    Task MigrateAndSeedDataAsync();
}

