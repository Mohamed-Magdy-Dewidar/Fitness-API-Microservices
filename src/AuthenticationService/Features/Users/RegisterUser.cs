using AuthenticationService.Contratcts.Users;
using AuthenticationService.Entities;
using AuthenticationService.Services;
using Contracts;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared;
namespace AuthenticationService.Features.Users;

public static class RegisterUser
{
    public record Command(string UserName, string PhoneNumber, string Email, string Password) : IRequest<Result<RegisterUserResponse>>;
    public record RegisterUserResponse(string AccessToken, string Email);

    public sealed class Validator : AbstractValidator<Command>
    {
          public Validator()
          {
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(50).WithMessage("Username is required and must not exceed 50 characters.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

          }

    }


    internal sealed class Handler : IRequestHandler<Command, Result<RegisterUserResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IValidator<Command> _validator;
        private readonly ITokenProvider _tokenProvider;
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(UserManager<ApplicationUser> userManager, IValidator<Command> validator,IPublishEndpoint publishEndpoint, ITokenProvider tokenProvider)
        {
            _userManager = userManager;
            _validator = validator;
            _tokenProvider = tokenProvider;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Result<RegisterUserResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Failure<RegisterUserResponse>(new Error("RegisterUser.Validation", validationResult.ToString()));

            var doesUserNameExists = await _userManager.FindByNameAsync(request.UserName);            
            if (doesUserNameExists != null)
                return Result.Failure<RegisterUserResponse>(new Error("RegisterUser.UserExists", "A user with this username already exists."));

            
            var doesEmailExist = await _userManager.FindByEmailAsync(request.Email);
            if (doesEmailExist != null)
                return Result.Failure<RegisterUserResponse>(new Error("RegisterUser.EmailExists", "A user with this email already exists."));


            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };


            var identityResult = await _userManager.CreateAsync(user, request.Password);
            if (!identityResult.Succeeded)
            {
                var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
                return Result.Failure<RegisterUserResponse>(new Error("RegisterUser.IdentityError", errors));
            }
            await _userManager.AddToRoleAsync(user, ApplicationRoles.TraineeRole);
            var token = await _tokenProvider.CreateTokenAsync(user);


            await _publishEndpoint.Publish(
                new UserCreatedEvent
                {
                    UserId = user.Id,
                    Email = user.Email,
                    CreatedOnUtc = DateTime.UtcNow,
                }, cancellationToken);

            var response = new RegisterUserResponse(token, user.Email);
            return Result.Success(response);
        }
    }

}
