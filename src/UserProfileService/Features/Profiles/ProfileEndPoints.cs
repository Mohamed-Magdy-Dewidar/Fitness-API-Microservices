using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Security.Claims;
using UserProfileService.Contracts.Profile;

namespace UserProfileService.Features.Profiles;


public class ProfileEndPoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/profiles").WithTags("Profiles");


        // --- GET /api/profiles/me ---
        group.MapGet("/me", async (
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? user.FindFirstValue("sub");

            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();

            var query = new GetUserProfile.Query(userId);
            var result = await sender.Send(query);

            if (result.IsFailure)
                return Results.NotFound(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("GetCurrentUserProfile")
        .Produces<CompleteProfileResponse>(StatusCodes.Status200OK)
        .Produces<Error>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status401Unauthorized)
        .RequireAuthorization();

        // --- GET /api/profiles/{userId} ---
        group.MapGet("/{userId}", async (
            string userId,
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var currentUserId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? user.FindFirstValue("sub");

            if (string.IsNullOrEmpty(currentUserId))
                return Results.Unauthorized();

            var query = new GetUserProfile.Query(userId);
            var result = await sender.Send(query);

            if (result.IsFailure)
                return Results.NotFound(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("GetUserProfileById")
        .Produces<CompleteProfileResponse>(StatusCodes.Status200OK)
        .Produces<Error>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status401Unauthorized)
        .RequireAuthorization(policy => policy.RequireRole(Shared.ApplicationRoles.FitnessTrainerRole));


        // --- PUT /api/profiles ---
        group.MapPut("/", async (
            [FromForm] CompleteProfileRequest request,
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? user.FindFirstValue("sub");

            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();

            var command = new CompleteUserProfile.Command(
                userId,
                request.Height,
                request.Weight,
                request.DateOfBirth,
                request.PrimaryGoal ?? string.Empty,
                request.ActivityLevel);

            var result = await sender.Send(command);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("CompleteUserProfile")
        .Produces<CompleteProfileResponse>(StatusCodes.Status200OK)
        .Produces<Error>(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status401Unauthorized)
        .DisableAntiforgery()
        .RequireAuthorization();


        // --- PATCH /api/profiles ---
        group.MapPatch("/", async (
            [FromBody] UpdateProfileRequest request,
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? user.FindFirstValue("sub");

            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();

            var command = new UpdateUserProfile.Command(
                userId,
                request.ActivityLevel ?? ActivityLevel.Beginner,
                request.Height,
                request.Weight,
                request.PrimaryGoal
                );

            var result = await sender.Send(command);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("UpdateUserProfile")
        .Produces<CompleteProfileResponse>(StatusCodes.Status200OK)
        .Produces<Error>(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status401Unauthorized)
        .RequireAuthorization();


     
        // --- POST /api/profiles/picture ---
        group.MapPost("/picture", async (
            IFormFile image, // Remove [FromForm] - Minimal APIs bind IFormFile automatically
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? user.FindFirstValue("sub");

            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();

            var command = new UpdateProfilePicture.Command(userId, image);
            var result = await sender.Send(command);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        })
        .WithName("UpdateProfilePicture")
        .Accepts<IFormFile>("multipart/form-data")
        .Produces<UpdateProfilePictureResponse>(StatusCodes.Status200OK)
        .Produces<Error>(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status401Unauthorized)
        .DisableAntiforgery()
        .RequireAuthorization();



        // --- DELETE /api/profiles ---
        group.MapDelete("/", async (
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? user.FindFirstValue("sub");

            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();

            var command = new DeleteUserProfile.Command(userId);
            var result = await sender.Send(command);

            if (result.IsFailure)
                return Results.BadRequest(result.Error);

            return Results.NoContent();
        })
        .WithName("DeleteUserProfile")
        .Produces(StatusCodes.Status204NoContent)
        .Produces<Error>(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status401Unauthorized)
        .RequireAuthorization();



        // --- Delete /api/profiles/{userId} ---
        group.MapDelete("/{userId}", async (
            string userId,
            ISender sender,
            ClaimsPrincipal user) =>
        {
            var currentUserId = user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? user.FindFirstValue("sub");

            if (string.IsNullOrEmpty(currentUserId))
                return Results.Unauthorized();

            var command = new DeleteUserProfile.Command(userId);
            var result = await sender.Send(command);

            if (result.IsFailure)
                return Results.NotFound(result.Error);

            return Results.NoContent();
        })
        .WithName("DeleteUserProfileById")
        .Produces(StatusCodes.Status204NoContent)
        .Produces<Error>(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status401Unauthorized)
        .RequireAuthorization(policy => policy.RequireRole(Shared.ApplicationRoles.FitnessTrainerRole));
    }
}