using Microsoft.EntityFrameworkCore;
using WorkOutService.Contracts;
using WorkOutService.DataBase;
using WorkOutService.DataBase.DataSeeding;

namespace WorkOutService.Data
{
    // Renamed to be specific to this service's responsibility
    public class WorkOutCatalogDbIntializer : IDbIntializer
    {
        private readonly WorkoutDbContext _context;
        private readonly ILogger<WorkOutCatalogDbIntializer> _logger;

        public WorkOutCatalogDbIntializer(WorkoutDbContext context, ILogger<WorkOutCatalogDbIntializer> logger)
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
                _logger.LogInformation("Applying pending migrations for WorkoutDbContext...");
                await _context.Database.MigrateAsync();
            }

            if (!await _context.Workouts.AnyAsync())
            {
                _logger.LogInformation("Seeding initial workout catalog data...");

                // Add Exercises
                await _context.Exercises.AddRangeAsync(WorkoutSeedData.GetExercises());

                // Add Workouts
                await _context.Workouts.AddRangeAsync(WorkoutSeedData.GetWorkouts());

                // Add Join Table Data (Instructions/Reps/Sets)
                await _context.WorkoutExercises.AddRangeAsync(WorkoutSeedData.GetWorkoutExercises());

                await _context.SaveChangesAsync();

                _logger.LogInformation("Successfully seeded {Count} Workouts and {ExerciseCount} Exercises.",
                    WorkoutSeedData.GetWorkouts().Count(), WorkoutSeedData.GetExercises().Count());
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
}

