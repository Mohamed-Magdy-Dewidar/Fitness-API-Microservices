using FluentValidation;
using MediatR;
using Shared;
using UserProfileService.Contracts.Profile;
using UserProfileService.DataBase;
using UserProfileService.Entities;

namespace UserProfileService.Features.Profiles;

public static class UpdateUserProfile
{
    public sealed record Command(string UserId,ActivityLevel ActivityLevel,double? Height,double? Weight,string? PrimaryGoal) :
        IRequest<Result<UpdateProfileResponse>>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(p => p.UserId).NotEmpty();

            RuleFor(p => p.Height)
                .GreaterThan(100).WithMessage("Height must be greater than 100cm.")
                .LessThan(250).WithMessage("Height must be less than 250cm.")
                .When(p => p.Height.HasValue);

            RuleFor(p => p.Weight)
                .GreaterThan(30).WithMessage("Weight must be greater than 30kg.")
                .LessThan(300).WithMessage("Weight must be less than 300kg.")
                .When(p => p.Weight.HasValue);

            RuleFor(p => p.PrimaryGoal)
                .NotEmpty()
                .MaximumLength(100)
                .When(p => !string.IsNullOrEmpty(p.PrimaryGoal));
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Result<UpdateProfileResponse>>
    {
        private readonly IValidator<Command> _validator;
        private readonly Repository<UserProfile, string> _repository;

        public Handler(IValidator<Command> validator, Repository<UserProfile, string> repository)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result<UpdateProfileResponse>> Handle(
            Command request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Failure<UpdateProfileResponse>(
                    new Error("UpdateProfile.Validation", validationResult.ToString()));

            var userProfile = await _repository.GetByIdAsync(request.UserId);

            if (userProfile == null)
                return Result.Failure<UpdateProfileResponse>(
                    new Error("UpdateProfile.NotFound", "User profile not found"));

            userProfile.Height = request.Height;
            userProfile.Weight = request.Weight;
            userProfile.PrimaryGoal = request.PrimaryGoal;
            userProfile.ActivityLevel = request.ActivityLevel;
            userProfile.UpdatedOnUtc = DateTime.UtcNow;

            _repository.SaveInclude(userProfile,
                nameof(userProfile.Height),
                nameof(userProfile.Weight),
                nameof(userProfile.PrimaryGoal),
                nameof(userProfile.ActivityLevel),
                nameof(userProfile.UpdatedOnUtc));

            await _repository.SaveChangesAsync(cancellationToken);

            return Result.Success(new UpdateProfileResponse(true));
        }
    }
}
