using Carter;
using MediatR;
using NutritionService.Contracts.Meals;
using NutritionService.Features.Meals.GetMealRecommendations;
using Shared;
using System.Security.Claims;


namespace NutritionService.Features.Nutrition
{
    public class NutritionEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/v1/nutrition").WithTags("Nutrition Catalog").RequireAuthorization();


            // Helper to get User ID securely (useful if we later add user-specific recommendation logic)
            string GetUserId(ClaimsPrincipal user) => user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue("sub") ?? string.Empty;






            // =======================================================
            // 1. GET /api/v1/nutrition/recommendations (List/Browse)
            // =======================================================
            group.MapGet("/recommendations", async (                
                [AsParameters] GetMealRecommendations.Query query,
                ISender sender,
                ClaimsPrincipal user) =>
            {
                if (string.IsNullOrEmpty(GetUserId(user))) return Results.Unauthorized();

                var result = await sender.Send(query);

               
                return result.IsFailure
                    ? Results.NotFound(result.Error)
                    : Results.Ok(result.Value);
            })
            .WithName("GetMealRecommendations")
            .Produces<IEnumerable<MealRecommendationDto>>(StatusCodes.Status200OK)
            .Produces<Error>(StatusCodes.Status404NotFound)
            .RequireAuthorization();








            // =======================================================
            // 2. GET /api/v1/nutrition/meals/{id} (Details)
            // =======================================================
            group.MapGet("/meals/{id:int}", async ( // Using :int to match your entity key type
                int id,
                ISender sender,
                ClaimsPrincipal user) =>
            {
                if (string.IsNullOrEmpty(GetUserId(user))) return Results.Unauthorized();

                var query = new GetMealDetails.Query(id);
                var result = await sender.Send(query);



                return result.IsFailure
                    ? Results.NotFound(new Error("RES_MEAL_NOT_FOUND", $"Meal with ID {id} not found."))
                    : Results.Ok(result.Value);
            })
            .WithName("GetMealDetails")
            .Produces<MealDetailResponse>(StatusCodes.Status200OK)
            .Produces<Error>(StatusCodes.Status404NotFound)
            .RequireAuthorization();
        }
    }
}