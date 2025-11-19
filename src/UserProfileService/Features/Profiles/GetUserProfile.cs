using FluentValidation;
using MediatR;
using Shared;
using UserProfileService.Contracts;
using UserProfileService.DataBase;
using UserProfileService.Entities;

namespace UserProfileService.Features.Profiles;

public static class GetUserProfile
{
    public record Query(string UserId) : IRequest<Result<GetUserProfileResponse>>;

    internal sealed class Handler : IRequestHandler<Query, Result<GetUserProfileResponse>>
    {
        private readonly Repository<UserProfile, string> _repository;

        public Handler(Repository<UserProfile, string> repository)
        {
            _repository = repository;
        }

        public async Task<Result<GetUserProfileResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var profile = await _repository.GetByIdAsync(request.UserId);

            if (profile is null)
                return Result.Failure<GetUserProfileResponse>(
                    new Error("GetProfile.NotFound", "User profile not found."));

            var response = new GetUserProfileResponse(
                profile.Id,
                profile.UserName,
                profile.Email,
                profile.ProfilePictureUrl,
                profile.DateOfBirth,
                profile.Weight,
                profile.Height,
                profile.PrimaryGoal,
                profile.ActivityLevel ?? ActivityLevel.Beginner,
                profile.CreatedOnUtc,
                profile.MemberSince);

            return Result.Success(response);
        }
    }
}