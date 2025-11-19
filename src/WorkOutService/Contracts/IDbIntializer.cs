namespace WorkOutService.Contracts;


public interface IDbIntializer
{
    Task MigrateAndSeedDataAsync();
}

