using Shared;

namespace ProgressTrackingService.Entities;


public class NutritionLog : BaseEntity<Guid>
{
    
    public string UserId { get; set; } = string.Empty;
    public Guid? RecipeId { get; set; }

    public string MealName { get; set; } = string.Empty;

    public string MealType { get; set; } = string.Empty;

    public int TotalCalories { get; set; }
    public decimal Protein { get; set; } 
    public decimal Carbs { get; set; }   
    public decimal Fats { get; set; }    
    public DateTime LoggedAtUtc { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }
    public string? Ingredients { get; set; }
}