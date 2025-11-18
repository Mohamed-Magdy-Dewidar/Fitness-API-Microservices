namespace UserProfileService.Contracts.Profile;


public record UpdateProfileResponse(bool Success)
{
    public string Message { get; init; } = "Profile updated successfully.";
    
}