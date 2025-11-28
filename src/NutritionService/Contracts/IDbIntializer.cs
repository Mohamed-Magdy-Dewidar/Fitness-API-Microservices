namespace NutritionService.Contracts;


public interface IDbIntializer
{
    Task MigrateAndSeedDataAsync();
}

