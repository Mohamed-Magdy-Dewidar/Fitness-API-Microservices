namespace NutritionService.Contracts.Meals;

public record MealDetailResponse(
       int Id,
       string Name,
       string Description,
       string MealType,
       int Calories,
       double Protein,
       double Carbs,
       double Fats,
       int PrepTimeMinutes,
       int CookTimeMinutes,
       string? ImageUrl,
       string? Instructions,
       IEnumerable<IngredientDto> Ingredients
);

public record IngredientDto(string Name, string Amount);
