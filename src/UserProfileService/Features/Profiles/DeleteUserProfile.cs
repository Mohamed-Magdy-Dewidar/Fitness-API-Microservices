using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;
using UserProfileService.Contracts;
using UserProfileService.Contracts.Profile;
using UserProfileService.DataBase;
using UserProfileService.Entities;

namespace UserProfileService.Features.Profiles;

public static class DeleteUserProfile
{
    public record Command(string UserId) : IRequest<Result<DeleteUserProfileResponse>>;

    internal sealed class Handler : IRequestHandler<Command, Result<DeleteUserProfileResponse>>
    {
        private readonly Repository<UserProfile, string> _repository;       

        public Handler(Repository<UserProfile, string> repository , IFileStorageService fileStorageService)
        {
            _repository = repository;
        }

        public async Task<Result<DeleteUserProfileResponse>> Handle(Command request, CancellationToken cancellationToken)
        {
            var profile = await _repository
                .FindByCondition(p => p.Id == request.UserId, trackChanges: true)
                .FirstOrDefaultAsync(cancellationToken);

            if (profile == null)
                return Result.Failure<DeleteUserProfileResponse>(
                    new Error("DeleteProfile.NotFound", "User profile not found."));

            await _repository.DeleteAsync(request.UserId);
            await _repository.SaveChangesAsync(cancellationToken);

            return Result.Success(new DeleteUserProfileResponse(Success: true));
        }
    }
}