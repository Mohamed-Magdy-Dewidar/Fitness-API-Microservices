using NutritionService.Entities.Enums;
using Shared;

namespace NutritionService.Entities;


public class MealIngredient : BaseEntity<int>
{

    public string Name { get; set; } = default!;
    public string Amount { get; set; } = default!;


    public int MealId { get; set; }
    public Meal Meal { get; set; }

}
