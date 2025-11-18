using Automatonymous;
using Shared;
namespace UserProfileService.Contracts.Profile;


public class CompleteProfileRequest
{
    public double Height { get; set; }
    public double Weight { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? PrimaryGoal { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
}
