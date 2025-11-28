namespace ProgressTrackingService.Contracts.ProgressTracking;

public record LogWeightEntryResponse(Guid EntryId, decimal NewWeight, DateOnly Date);
