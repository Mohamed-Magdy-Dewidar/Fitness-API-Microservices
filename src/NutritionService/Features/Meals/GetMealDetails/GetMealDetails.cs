using Microsoft.EntityFrameworkCore;
using NutritionService.DataBase.Repositorys;
using NutritionService.Entities;
using Shared;
using StackExchange.Redis;
using System.Text.Json;
using MediatR;
using NutritionService.Contracts.Meals;

namespace NutritionService.Features.Nutrition;

public static class GetMealDetails
{
    public record Query(int Id) : IRequest<Result<MealDetailResponse>>;

    

   

    internal sealed class Handler : IRequestHandler<Query, Result<MealDetailResponse>>
    {
        private readonly Repository<Meal, int> _mealRepo;
        private readonly Repository<MealIngredient, int> _mealIngredientRepo;
        private readonly Repository<NutritionFact, int> _nutritionFactRepo;
        private readonly IDatabase _redis;
        private const string CacheKeyPrefix = "meal:details:";
        private static readonly TimeSpan CacheExpiry = TimeSpan.FromMinutes(30);

        public Handler(
            Repository<Meal, int> mealRepo,
            Repository<MealIngredient, int> mealIngredientRepo,
            Repository<NutritionFact, int> nutritionFactRepo,
            IConnectionMultiplexer redis)
        {
            _mealRepo = mealRepo;
            _mealIngredientRepo = mealIngredientRepo;
            _nutritionFactRepo = nutritionFactRepo;
            _redis = redis.GetDatabase();
        }

        public async Task<Result<MealDetailResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var cacheKey = CacheKeyPrefix + request.Id;

            var cachedValue = await _redis.StringGetAsync(cacheKey);
            if (cachedValue.HasValue)
            {
                var cachedResponse = JsonSerializer.Deserialize<MealDetailResponse>(cachedValue);
                if (cachedResponse is not null)
                    return Result.Success(cachedResponse);
            }

            var meal = await _mealRepo
                .GetAll(m => m.Id == request.Id)
                .Select(m => new
                {
                    m.Id,
                    m.Name,
                    m.Description,
                    MealType = m.mealType.ToString(),
                    m.PrepTimeInMinutes,
                    CookTimeMinutes = m.PrepTimeInMinutes, // Use PrepTime if CookTime not stored separately
                    m.ImageUrl,
                    m.Instructions
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (meal is null)
                return Result.Failure<MealDetailResponse>(
                    new Error("RES_MEAL_NOT_FOUND", $"Meal with ID {request.Id} not found.")
                );

            var nutrition = await _nutritionFactRepo
                .GetAll(nf => nf.MealId == request.Id)
                .Select(nf => new
                {
                    nf.Calories,
                    nf.Protein,
                    nf.Carbs,
                    nf.Fats
                })
                .FirstOrDefaultAsync(cancellationToken);

            var ingredients = await _mealIngredientRepo
                .GetAll(mi => mi.MealId == request.Id)
                .Select(mi => new IngredientDto(mi.Name, mi.Amount))
                .ToListAsync(cancellationToken);

            var response = new MealDetailResponse(
                meal.Id,
                meal.Name,
                meal.Description,
                meal.MealType,
                nutrition?.Calories ?? 0,
                nutrition?.Protein ?? 0,
                nutrition?.Carbs ?? 0,
                nutrition?.Fats ?? 0,
                meal.PrepTimeInMinutes,
                meal.CookTimeMinutes,
                meal.ImageUrl,
                meal.Instructions,
                ingredients
            );


            await _redis.StringSetAsync(cacheKey, JsonSerializer.Serialize(response), CacheExpiry);

            return Result.Success(response);
        }
    }
}
