
using NutritionService.Entities.Enums;
using Shared;
namespace NutritionService.Entities;

public class MealPlan : BaseEntity<int> 
{

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int CalorieTarget { get; set; }

    public ICollection<Meal> Meals { get; set; }

}
