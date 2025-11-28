namespace Contracts;

public record WeightUpdatedEvent
{
    public required string UserId { get; init; }
    public required decimal NewWeight { get; init; }
    public required DateOnly DateRecorded { get; init; }
}