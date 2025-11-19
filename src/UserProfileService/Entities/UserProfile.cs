using Shared;
namespace UserProfileService.Entities;




public class UserProfile : BaseEntity<string>
{

    public string? UserName { get; init; }

    public string? Email { get; set; }

    public DateTime MemberSince { get; set; } = DateTime.UtcNow;

    public string? ProfilePictureUrl { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public double? Weight { get; set; }
    
    public double? Height { get; set; }

    public string? PrimaryGoal { get; set; } 

    public ActivityLevel? ActivityLevel { get; set; }
}

