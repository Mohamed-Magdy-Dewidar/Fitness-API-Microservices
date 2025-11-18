using FluentValidation;
using MediatR;
using Shared;
using UserProfileService.Contracts;
using UserProfileService.Contracts.Profile;
using UserProfileService.DataBase;
using UserProfileService.Entities;

namespace UserProfileService.Features.Profiles;

public static class UpdateProfilePicture
{
    public record Command(string UserId, IFormFile Image) : IRequest<Result<UpdateProfilePictureResponse>>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.Image).NotNull().WithMessage("Image file is required.");
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Result<UpdateProfilePictureResponse>>
    {
        private readonly IValidator<Command> _validator;
        private readonly Repository<UserProfile, string> _repository;
        private readonly IFileStorageService _fileStorage;
        private readonly ILogger<Handler> _logger;

        public Handler(
            IValidator<Command> validator,
            ILogger<Handler> logger,
            Repository<UserProfile, string> repository,
            IFileStorageService fileStorage)
        {
            _validator = validator;
            _repository = repository;
            _fileStorage = fileStorage;
            _logger = logger;
        }

        public async Task<Result<UpdateProfilePictureResponse>> Handle(
            Command request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Failure<UpdateProfilePictureResponse>(
                    new Error("UpdateProfilePicture.Validation", validationResult.ToString()));
            }

            var profile = await _repository.GetByIdAsync(request.UserId);

            if (profile is null)
            {
                return Result.Failure<UpdateProfilePictureResponse>(
                    new Error("UpdateProfilePicture.NotFound", "User profile not found."));
            }

            try
            {
                await _fileStorage.DeleteFileAsync(profile.ProfilePictureUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting existing profile picture for {UserId}", request.UserId);
            }

            string newFileUrl = "";
            try
            {
                newFileUrl = await _fileStorage.SaveFileAsync(request.Image, request.UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save new profile picture for {UserId}", request.UserId);
            }

            if (string.IsNullOrEmpty(newFileUrl))
            {
                return Result.Failure<UpdateProfilePictureResponse>(
                    new Error("UpdateProfilePicture.FileStorageError", "Failed to store the new profile picture."));
            }

            profile.ProfilePictureUrl = newFileUrl;
            profile.UpdatedOnUtc = DateTime.UtcNow;

            _repository.SaveInclude(profile,
                nameof(profile.ProfilePictureUrl),
                nameof(profile.UpdatedOnUtc));

            await _repository.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("User {UserId} successfully updated their profile picture.", request.UserId);

            return Result.Success(new UpdateProfilePictureResponse(newFileUrl));
        }
    }
}
