using AuthenticationService.Entities;


namespace AuthenticationService.Services
{
    public interface ITokenProvider
    {
        public Task<string> CreateTokenAsync(ApplicationUser user);
    }
}
