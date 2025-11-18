using UserProfileService.Contracts;
namespace UserProfileService.Extensions;


public static class MigrationExtensions
{
        public async static Task IntializeDataBase(this WebApplication app)
        {
            using var Scope = app.Services.CreateScope();

            var DataSeedingObj = Scope.ServiceProvider.GetRequiredService<IDbIntializer>();
            await DataSeedingObj.MigrateAndSeedDataAsync();

        }
}

