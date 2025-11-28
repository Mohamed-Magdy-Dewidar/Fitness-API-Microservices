using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.DataBase.DataSeeding;
using ProgressTrackingService.Contracts;


namespace ProgressTrackingService.DataBase;
public class ProgressTrackingDbIntializer : IDbIntializer
{
        private readonly ProgressTrackingDbContext _context;
        private readonly ILogger<ProgressTrackingDbIntializer> _logger;

        public ProgressTrackingDbIntializer(ProgressTrackingDbContext context,ILogger<ProgressTrackingDbIntializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task MigrateAndSeedDataAsync()
        {
            await WaitForDatabaseAsync();

            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                _logger.LogInformation("Applying pending migrations for ProgressTrackingDbContext...");
                await _context.Database.MigrateAsync();
            }

            if (!await _context.WorkoutLogs.AnyAsync())
            {
                _logger.LogInformation("Seeding Progress Tracking data...");

            
                await _context.WorkoutLogs.AddRangeAsync(ProgressTrackingSeedData.GetCompletedWorkoutLogs());

                await _context.NutritionLogs.AddRangeAsync(ProgressTrackingSeedData.GetNutritionLogs());

                await _context.ActiveSessions.AddRangeAsync(ProgressTrackingSeedData.GetActiveSessions());

                await _context.SaveChangesAsync();

                _logger.LogInformation("Successfully seeded initial Progress Tracking data.");
            }
        }

        private async Task WaitForDatabaseAsync()
        {
            const int MaxRetries = 10;
            const int DelaySeconds = 5;
            for (int i = 0; i < MaxRetries; i++)
            {
                try
                {
                    await _context.Database.EnsureCreatedAsync();
                    _logger.LogInformation("✅ Database ensured!");                    
                    if (await _context.Database.CanConnectAsync())
                    {
                        _logger.LogInformation("✅ Database is connectable!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning($"Database connection attempt {i + 1} failed: {ex.Message}. Retrying in {DelaySeconds}s...");
                }
                await Task.Delay(TimeSpan.FromSeconds(DelaySeconds));
            }

            _logger.LogError("Database connection could not be established after {MaxRetries} retries.", MaxRetries);
            throw new Exception("Database connection failed.");
        }
}


