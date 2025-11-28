using MediatR;
using Microsoft.EntityFrameworkCore;
using NutritionService.Contracts.Meals;
using NutritionService.DataBase.Repositorys;
using NutritionService.Entities;
using NutritionService.Entities.Enums;
using Shared;
using StackExchange.Redis;
using System.Text.Json;

namespace NutritionService.Features.Meals.GetMealRecommendations;


static class GetMealRecommendations
{
    public record Query(MealType? MealType = null, int? MaxCalories = null, double? MinProtein = null) : IRequest<Result<IEnumerable<MealRecommendationDto>>>;



    internal sealed class GetMealRecommendationsHandler : IRequestHandler<Query, Result<IEnumerable<MealRecommendationDto>>>
    {
        private readonly Repository<Meal, int> _mealRepo;
        private readonly IDatabase _redis;
        private const string CacheKeyPrefix = "meal_recommendations:";

        public GetMealRecommendationsHandler(
            Repository<Meal, int> mealRepo,
            IConnectionMultiplexer redis)
        {
            _mealRepo = mealRepo;
            _redis = redis.GetDatabase();
        }

        public async Task<Result<IEnumerable<MealRecommendationDto>>> Handle(
            Query request,
            CancellationToken cancellationToken)
        {

            var cacheKey = $"{CacheKeyPrefix}" +
                           $"mealType:{request.MealType}_maxCalories:{request.MaxCalories}_minProtein:{request.MinProtein}";


            var cachedValue = await _redis.StringGetAsync(cacheKey);
            if (cachedValue.HasValue)
            {
                var cachedResult = JsonSerializer.Deserialize<IEnumerable<MealRecommendationDto>>(cachedValue);
                if (cachedResult is not null)
                    return Result.Success(cachedResult);
            }

            var query = _mealRepo.GetAll(m => true)
                .Include(m => m.NutritionFacts)
                .AsQueryable();

            if (request.MealType.HasValue)
                query = query.Where(m => m.mealType == request.MealType.Value);

            if (request.MaxCalories.HasValue)
                query = query.Where(m => m.NutritionFacts.Calories <= request.MaxCalories.Value);

            if (request.MinProtein.HasValue)
                query = query.Where(m => m.NutritionFacts.Protein >= request.MinProtein.Value);


            var meals = await query
                .Select(m => new MealRecommendationDto(
                    m.Id,
                    m.Name,
                    m.Description,
                    m.mealType.ToString(),
                    m.NutritionFacts.Calories,
                    m.NutritionFacts.Protein,
                    m.NutritionFacts.Carbs,
                    m.NutritionFacts.Fats,
                    m.PrepTimeInMinutes,
                    m.ImageUrl,
                    m.Difficulty,
                    m.IsPremium
                ))
                .ToListAsync(cancellationToken);

            await _redis.StringSetAsync(
                cacheKey,
                JsonSerializer.Serialize(meals),
                TimeSpan.FromMinutes(5)
            );


            return Result.Success(meals.AsEnumerable());
        }
    }
}