namespace NutritionService.Contracts.Meals;

public record MealRecommendationDto(
    int Id,
    string Name,
    string Description,
    string MealType,
    int Calories,
    double Protein,
    double Carbs,
    double Fats,
    int PrepTime,
    string ImageUrl,
    string Difficulty,
    bool IsPremium
);