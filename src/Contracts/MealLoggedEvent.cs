namespace Contracts;

public record MealLoggedEvent
    {
        public required Guid LogId { get; init; }
        public required string UserId { get; init; }
        public required int TotalCalories { get; init; }
        public required decimal Protein { get; init; }
        public required decimal Carbs { get; init; }
        public required decimal Fats { get; init; }
        public required DateTime LoggedAtUtc { get; init; }
    }
