using Shared;
namespace UserProfileService.Contracts.Profile;

public record UpdateProfileRequest(double? Height, double? Weight, string? PrimaryGoal, ActivityLevel? ActivityLevel);
