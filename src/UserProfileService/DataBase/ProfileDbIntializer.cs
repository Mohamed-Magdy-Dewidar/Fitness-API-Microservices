using Microsoft.EntityFrameworkCore;
using Shared;
using UserProfileService.Contracts;
using UserProfileService.DataBase;
using UserProfileService.Entities;

namespace UserProfileService.Data
{
    public class ProfileDbIntializer : IDbIntializer
    {
        private readonly UserProfileDbContext _context;
        private readonly ILogger<ProfileDbIntializer> _logger;

        public ProfileDbIntializer(
            UserProfileDbContext context,
            ILogger<ProfileDbIntializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task MigrateAndSeedDataAsync()
        {
            // 1. Wait for the database to be connectable
            await WaitForDatabaseAsync();

            // 2. Run migrations
            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                _logger.LogInformation("Applying pending migrations for UserProfileDbContext...");
                await _context.Database.MigrateAsync();
            }

            // 3. Seed Profiles (if they don't exist)
            if (!await _context.UserProfiles.AnyAsync())
            {
                _logger.LogInformation("Seeding user profiles...");

                var profiles = new List<UserProfile>
                {

                       new UserProfile
                      {
                        Id = SeedData.User01_Id,
                        Email = "mohamedMagdy@gmail.com",
                        UserName = "Mohamed Magdy",
                        // Full Data
                        DateOfBirth = new DateOnly(1995, 5, 20),
                        Weight = 75.5,
                        Height = 180,
                        PrimaryGoal = "Build Muscle",
                        ActivityLevel = ActivityLevel.Monster, // Use the Enum here!
                        MemberSince = DateTime.UtcNow.AddMonths(-6)
                    },

                    // User 02 - Partially Completed
                    new UserProfile
                    {
                        Id = SeedData.User02_Id,
                        Email = "Omar@gmail.com",       
                        UserName = "Omar Ahmed",
                        // Partial Data
                        DateOfBirth = new DateOnly(1998, 12, 1),
                        ActivityLevel = ActivityLevel.Beginer,
                        MemberSince = DateTime.UtcNow.AddDays(-10)
                    },

                    // User 03
                    new UserProfile
                    {
                        Id = SeedData.User03_Id, // Use the shared ID
                        Email = "Omarmohamed@gmail.com",
                        UserName = "Omar Mohamed",

                    }
                };

                await _context.UserProfiles.AddRangeAsync(profiles);
                await _context.SaveChangesAsync();
            }
        }


        private async Task WaitForDatabaseAsync()
        {
            const int MaxRetries = 20;
            const int DelaySeconds = 10;
            for (int i = 0; i < MaxRetries; i++)
            {
                try
                {
                    // Try to connect - this will work even if database doesn't exist
                    await _context.Database.EnsureCreatedAsync();
                    _logger.LogInformation("✅ Database ensured!");
                    break;
                }
                catch (Exception ex) when (i < MaxRetries - 1)
                {
                    _logger.LogWarning($"Database creation attempt {i + 1} failed: {ex.Message}. Retrying...");
                    await Task.Delay(DelaySeconds);
                }
            }
        }
    }
}