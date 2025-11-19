namespace WorkOutService.Contracts;

public record GetWorkOutsResponse(Guid Id, string? Name, string? Description, string? Category, string? Difficulty, int? Duration, string? ImageUrl);
