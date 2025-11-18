namespace UserProfileService.Contracts.Profile;



public record UpdateProfilePictureResponse(string ProfilePictureUrl)
{
    public string Message { get; init; } = "Profile picture updated successfully.";
}
