using AuthenticationService.DataBase.Identity;
using AuthenticationService.Entities;
using AuthenticationService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace AuthenticationService.DataBase
{
    public class DbIntializer(AuthDbContext _context, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager, ILogger<DbIntializer> _logger, IConfiguration _configuration) : IDbIntializer
    {
        public async Task IdentitySeedDataAsync()
        {
            try
            {

                await WaitForDatabaseAsync();
                
                
                var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    _logger.LogInformation("Applying pending migrations for FitnessAppAuthDbContext...");
                    await _context.Database.MigrateAsync();
                }

                if (!await _roleManager.Roles.AnyAsync())
                {
                    _logger.LogInformation("Seeding roles...");
                    await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.TraineeRole));
                    await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.FitnessTrainerRole));
                }

                if (!await _userManager.Users.AnyAsync())
                {
                    _logger.LogInformation("Seeding users...");
                    var passwordUser01 = _configuration["SeedData:UserO1Password"];
                    var passwordUser02 = _configuration["SeedData:UserO2Password"];
                    var passwordUser03 = _configuration["SeedData:UserO3Password"];

                    var user01 = new ApplicationUser()
                    {
                        Id = Shared.SeedData.User01_Id,
                        Email = "mohamedMagdy@gmail.com",
                        PhoneNumber = "09123456789",
                        UserName = "mohamedMagdy",
                        EmailConfirmed = true
                    };
                    var user02 = new ApplicationUser()
                    {
                        Id = Shared.SeedData.User02_Id,
                        Email = "Omar@gmail.com",
                        PhoneNumber = "09123456789",
                        UserName = "OmarMohamed",
                        EmailConfirmed = true
                    };

                    var user03 = new ApplicationUser()
                    {
                        Id = Shared.SeedData.User03_Id,
                        Email = "Omarmohamed@gmail.com",
                        PhoneNumber = "09443456789",
                        UserName = "OmarMagdy",
                        EmailConfirmed = true
                    };

                    await _userManager.CreateAsync(user01, passwordUser01!);
                    await _userManager.CreateAsync(user02, passwordUser02!);
                    await _userManager.CreateAsync(user03, passwordUser03!);

                    await _userManager.AddToRoleAsync(user01, ApplicationRoles.TraineeRole);
                    await _userManager.AddToRoleAsync(user02, ApplicationRoles.FitnessTrainerRole);
                    await _userManager.AddToRoleAsync(user03, ApplicationRoles.FitnessTrainerRole);
                    // Note: No need for SaveChangesAsync on identity context here, UserManager handles it.
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during identity data seeding.");
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