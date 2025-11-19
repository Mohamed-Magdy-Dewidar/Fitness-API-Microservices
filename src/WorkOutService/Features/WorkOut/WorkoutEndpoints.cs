using Carter;
using MediatR;
using Shared;
using System.Security.Claims;
using WorkOutService.Contracts;

namespace WorkOutService.Features.WorkOut;



public class WorkoutEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/workouts").WithTags("Workouts");


        // --- Helper to get User ID securely ---
        string GetUserId(ClaimsPrincipal user) => user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue("sub") ?? string.Empty;


        // =======================================================
        // 1. GET /api/v1/workouts (List/Browse)
        // =======================================================
        group.MapGet("/", async (
            ISender sender,
            ClaimsPrincipal user) =>
        {
            if (string.IsNullOrEmpty(GetUserId(user))) return Results.Unauthorized();

            var query = new GetWorkOuts.Query();
            var result = await sender.Send(query);

            return result.IsFailure
                ? Results.NotFound(result.Error)
                : Results.Ok(result.Value); 
        })
        .WithName("GetWorkoutSummaryList")
        .Produces<GetWorkOutsResponse>(StatusCodes.Status200OK)
        .Produces<Error>(StatusCodes.Status404NotFound)
        .RequireAuthorization();


        // =======================================================
        // 2. GET /api/v1/workouts/{id} (Details)
        // =======================================================
        group.MapGet("/{id:guid}", async (
            Guid id,
            ISender sender,
            ClaimsPrincipal user) =>
        {
            if (string.IsNullOrEmpty(GetUserId(user))) return Results.Unauthorized();

            var query = new GetWorkOutDetails.Query(id);
            var result = await sender.Send(query);

            return result.IsFailure
                ? Results.NotFound(new Error("RES_WORKOUT_NOT_FOUND", $"Workout with ID {id} not found."))
                : Results.Ok(result.Value);
        })
        .WithName("GetWorkoutDetails")
        .Produces<GetWorkOutDetailsResponse>(StatusCodes.Status200OK)
        .Produces<Error>(StatusCodes.Status404NotFound)
        .RequireAuthorization();


        // =======================================================
        // 3. GET /api/v1/workouts/category/{categoryName} (Filter)
        // =======================================================
        group.MapGet("/category/{categoryName}", async (
            string categoryName,            
            ISender sender,
            ClaimsPrincipal user) =>
        {
            if (string.IsNullOrEmpty(GetUserId(user))) return Results.Unauthorized();


            var Query = new GetWorkoutsByCategory.Query(categoryName);           
            var result = await sender.Send(Query);

            return result.IsFailure
                ? Results.NotFound(result.Error)
                : Results.Ok(result.Value);
        })
        .WithName("GetWorkoutsByCategory")
        .Produces<IEnumerable<GetWorkoutByCategoryResponse>>(StatusCodes.Status200OK)
        .Produces<Error>(StatusCodes.Status404NotFound)
        .RequireAuthorization();


        // =======================================================
        // 4. POST /api/v1/workouts/{id}/start (Start Session)
        // =======================================================
        group.MapPost("/{id:guid}/start", async (
            Guid id,
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var userId = GetUserId(user);
            if (string.IsNullOrEmpty(userId)) return Results.Unauthorized();

            var command = new StartWorkOutSession.Command(id, userId);

            // 2. Send the command (publishes event and caches session ID)
            var result = await sender.Send(command);

            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.BadRequest(result.Error);
        })
        .WithName("StartWorkoutSession")
        .Produces<StartWorkOutSessionResponse>(StatusCodes.Status200OK)
        .Produces<Error>(StatusCodes.Status400BadRequest)
        .RequireAuthorization();
    }
}


