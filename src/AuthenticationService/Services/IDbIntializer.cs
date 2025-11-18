namespace AuthenticationService.Services;


public interface IDbIntializer
{
    Task IdentitySeedDataAsync();
}

