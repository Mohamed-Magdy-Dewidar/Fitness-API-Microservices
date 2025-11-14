using AuthenticationService.Contratcts.Users;
using AuthenticationService.Entities;
using AuthenticationService.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared;
namespace AuthenticationService.Features.Users;

public static class LoginUser
{
        public record Command(string Email, string Password) : IRequest<Result<LoginResponse>>;

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Email).NotEmpty().EmailAddress();
                RuleFor(c => c.Password).NotEmpty();
            }
        }

        internal sealed class Handler : IRequestHandler<Command, Result<LoginResponse>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IValidator<Command> _validator;
            private readonly ITokenProvider _tokenProvider;

            public Handler(UserManager<ApplicationUser> userManager, IValidator<Command> validator, ITokenProvider tokenProvider)
            {
                _userManager = userManager;
                _validator = validator;
                _tokenProvider = tokenProvider;
            }

            public async Task<Result<LoginResponse>> Handle(Command request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                if (!validationResult.IsValid)
                    return Result.Failure<LoginResponse>(new Error("Login.Validation", validationResult.ToString()));
                
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user is null)
                    return Result.Failure<LoginResponse>(new Error("Login.InvalidCredentials", "Invalid email or password."));
                

                var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!isPasswordCorrect)
                    return Result.Failure<LoginResponse>(new Error("Login.InvalidCredentials", "Invalid email or password."));
                
                var token = await _tokenProvider.CreateTokenAsync(user);

                var response = new LoginResponse(token);
                return Result.Success(response);
            }
        }
    
}