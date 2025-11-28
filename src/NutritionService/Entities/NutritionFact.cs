using NutritionService.Entities.Enums;
using Shared;
namespace NutritionService.Entities;


public class NutritionFact : BaseEntity<int>
{
    public int Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fats { get; set; }
    public double Fiber { get; set; }

    public int MealId { get; set; }
    public Meal Meal { get; set; }

}
