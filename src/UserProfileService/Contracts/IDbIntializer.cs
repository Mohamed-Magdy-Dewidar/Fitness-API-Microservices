namespace UserProfileService.Contracts;


public interface IDbIntializer
{
    Task MigrateAndSeedDataAsync();
}

