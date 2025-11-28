using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProgressTrackingService.Contracts.ProgressTracking;
using ProgressTrackingService.Features.ProgressTracking.AbortSession;
using ProgressTrackingService.Features.ProgressTracking.LogWeightEntry;
using ProgressTrackingService.Features.ProgressTracking.SubmittWorkOut;
using Shared;
using System.Security.Claims;

namespace ProgressTrackingService.Features.Progress;



public class ProgressEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Requires authorization by default
        var group = app.MapGroup("api/v1/progress").WithTags("Progress Tracking").RequireAuthorization();

        // Helper to get User ID securely
        string GetUserId(ClaimsPrincipal user) => user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue("sub") ?? string.Empty;

        // =======================================================
        // 1. POST /api/v1/progress/workouts (Log Workout Completion)
        // Orchestrates DB save, Redis cleanup, and MQ publishing.
        // =======================================================
        group.MapPost("/workouts", async (
                   [FromBody] SubmitWorkoutOrchestrator.Command command,
                   ISender sender,
                   ClaimsPrincipal user) =>
        {
            var userId = GetUserId(user);
            if (string.IsNullOrEmpty(userId)) return Results.Unauthorized();

            command.UserId = userId;


            Result<LogWorkoutResponse> result = await  sender.Send(command);
            
            // Check for null result (shouldn't happen with MediatR but is safer)
            if (result == null)
                return Results.StatusCode(StatusCodes.Status500InternalServerError);

            // Returns 201 Created on success
            return result.IsSuccess
                ? Results.Created($"/api/v1/progress/logs/{result.Value.LogId}", result.Value)
                : Results.BadRequest(result.Error); // 400 Bad Request or Error
        })
               .WithName("LogWorkoutCompletion")
               .Produces<LogWorkoutResponse>(StatusCodes.Status201Created)
               .Produces<Error>(StatusCodes.Status400BadRequest);


        // =======================================================
        // 2. POST /api/v1/progress/nutrition (Log Meal Entry)
        // Publishes MealLoggedEvent to FCE.
        // =======================================================
        group.MapPost("/nutrition", async (
            [FromBody] LogWeightEntryOrchestrator.Command command,
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var userId = GetUserId(user);
            if (string.IsNullOrEmpty(userId)) return Results.Unauthorized();

            command.UserId = userId;

            var result = await sender.Send(command);

            // Returns 201 Created on success
            return result.IsSuccess
                ? Results.Created($"/api/v1/progress/nutrition/{result.Value.EntryId}", result.Value)
                : Results.BadRequest(result.Error);
        })
        .WithName("LogMealEntry")
        .Produces<LogMealEntryResponse>(StatusCodes.Status201Created)
        .Produces<Error>(StatusCodes.Status400BadRequest);


        // =======================================================
        // 3. PUT /api/v1/progress/sessions/{sessionId}/abort (Abort Session)
        // Cleans up Redis and marks the session as Canceled in SQL.
        // =======================================================
        group.MapPut("/sessions/{sessionId:guid}/abort", async (
            Guid sessionId,
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var userId = GetUserId(user);
            if (string.IsNullOrEmpty(userId)) return Results.Unauthorized();

            var command = new AbortActiveSessionOrchestrator.Command(userId , sessionId);

            var result = await sender.Send(command);

            // Returns 204 No Content for a successful status update/cleanup
            return result.IsSuccess
                ? Results.NoContent()
                : Results.NotFound(result.Error); // 404 Not Found if session ID doesn't exist
        })
        .WithName("AbortActiveSession")
        .Produces(StatusCodes.Status204NoContent)
        .Produces<Error>(StatusCodes.Status404NotFound);
























        // --- FUTURE READ ENDPOINTS ---
        // group.MapGet("/", GetProgressSummary)
        // group.MapGet("/active-session", GetActiveSessionStatus)
    }
}