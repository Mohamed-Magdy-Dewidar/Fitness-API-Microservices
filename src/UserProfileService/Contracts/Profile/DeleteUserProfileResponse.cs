namespace UserProfileService.Contracts.Profile;   
    


public record DeleteUserProfileResponse(bool Success)
{
    public string Message { get; init; } = "Profile deleted successfully.";
}