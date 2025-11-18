using Shared;

public record GetUserProfileResponse(string UserId, string UserName , string Email, string? ProfilePictureUrl, DateOnly? DateOfBirth, double? Weight, double? Height, string? PrimaryGoal, ActivityLevel ActivityLevel, DateTime CreatedOnUtc , DateTime MemberSince)
{
}

