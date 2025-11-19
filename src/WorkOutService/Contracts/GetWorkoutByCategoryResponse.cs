namespace WorkOutService.Contracts;

public record GetWorkoutByCategoryResponse(Guid Id, string? Name, string? Description, string? Category, string? Difficulty, int? Duration, string? ImageUrl);