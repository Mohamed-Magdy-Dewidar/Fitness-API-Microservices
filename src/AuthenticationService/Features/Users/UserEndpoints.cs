using AuthenticationService.Contratcts.Users;
using Carter;
using MediatR;
namespace AuthenticationService.Features.Users;

public class UserEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        var group = app.MapGroup("api/users").WithTags("Users");



        // --- User Register ---
        group.MapPost("/register", async (RegisterUserRequest request, ISender sender) =>
        {
            var command = new RegisterUser.Command(
                request.UserName,                
                request.PhoneNumber,
                request.Email,
                request.Password);

            var result = await sender.Send(command);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("RegisterUser");



        // --- User Login ---
        group.MapPost("/login", async (LoginRequest request, ISender sender) =>
        {
            var command = new LoginUser.Command(request.Email, request.Password);
            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                // For a failed login, always return 401 Unauthorized for security
                return Results.Unauthorized();
            }

            return Results.Ok(result.Value);
        })
        .WithName("LoginUser");
    }
}
