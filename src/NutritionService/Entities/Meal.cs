using NutritionService.Entities.Enums;
using Shared;
namespace NutritionService.Entities;

public class Meal : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public MealType mealType { get; set; }
    public int PrepTimeInMinutes { get; set; }
    public string Difficulty { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public bool IsPremium { get; set; } = false;


    public string Instructions { get; set; } = default!; 

    #region Relationships
    public int MealPlanId { get; set; }
    public MealPlan MealPlan { get; set; }

    public NutritionFact NutritionFacts { get; set; }

    public ICollection<MealIngredient> MealIngredients { get; set; }
    #endregion
}
