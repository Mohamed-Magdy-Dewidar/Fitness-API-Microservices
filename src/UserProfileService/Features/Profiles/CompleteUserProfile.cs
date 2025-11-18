using FluentValidation;
using MediatR;
using Shared;
using UserProfileService.Contracts.Profile;
using UserProfileService.DataBase;
using UserProfileService.Entities;

namespace UserProfileService.Features.Profiles;

public static class CompleteUserProfile
{
    public record Command(
        string UserId,
        double Height,
        double Weight,
        DateOnly DateOfBirth,
        string PrimaryGoal,
        ActivityLevel ActivityLevel) : IRequest<Result<CompleteProfileResponse>>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(p => p.Height)
                .GreaterThan(100).WithMessage("Height must be greater than 100cm.")
                .LessThan(250).WithMessage("Height must be less than 250cm.");

            RuleFor(p => p.Weight)
                .GreaterThan(30).WithMessage("Weight must be greater than 30kg.")
                .LessThan(300).WithMessage("Weight must be less than 300kg.");

            RuleFor(p => p.DateOfBirth)
                .Must(d => d < DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-16)))
                .WithMessage("You must be at least 16 years old.");

            RuleFor(p => p.PrimaryGoal)
                .NotEmpty()
                .MaximumLength(100);
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Result<CompleteProfileResponse>>
    {
        private readonly IValidator<Command> _validator;
        private readonly Repository<UserProfile, string> _repository;

        public Handler(IValidator<Command> validator, Repository<UserProfile, string> repository)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result<CompleteProfileResponse>> Handle(
            Command request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Failure<CompleteProfileResponse>(
                    new Error("CompleteProfile.Validation", validationResult.ToString()));
            }

            var profile = await _repository.GetByIdAsync(request.UserId);

            if (profile is null)
            {
                return Result.Failure<CompleteProfileResponse>(
                    new Error("CompleteProfile.NotFound", "User profile not found."));
            }

            profile.Height = request.Height;
            profile.Weight = request.Weight;
            profile.ActivityLevel = request.ActivityLevel;
            profile.DateOfBirth = request.DateOfBirth;
            profile.PrimaryGoal = request.PrimaryGoal;
            profile.UpdatedOnUtc = DateTime.UtcNow;

            _repository.SaveInclude(profile,
                nameof(profile.Height),
                nameof(profile.Weight),
                nameof(profile.ActivityLevel),
                nameof(profile.DateOfBirth),
                nameof(profile.PrimaryGoal),
                nameof(profile.UpdatedOnUtc));

            await _repository.SaveChangesAsync(cancellationToken);

            var response = new CompleteProfileResponse(
                profile.Id,
                profile.Email,
                profile.ProfilePictureUrl,
                profile.DateOfBirth,
                profile.Weight,
                profile.Height,
                profile.PrimaryGoal,
                profile.ActivityLevel,
                profile.CreatedOnUtc
            );

            return response;
        }
    }
}