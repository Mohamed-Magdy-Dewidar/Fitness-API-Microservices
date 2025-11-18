using Shared;
namespace UserProfileService.Contracts.Profile;

public record CompleteProfileResponse(string UserId, string Email, string? ProfilePictureUrl, DateOnly? DateOfBirth, double? Weight, double? Height, string? PrimaryGoal, ActivityLevel ActivityLevel, DateTime CreatedOnUtc)
{
    public DateTime MemberSince { get; set; } = DateTime.UtcNow;
}
