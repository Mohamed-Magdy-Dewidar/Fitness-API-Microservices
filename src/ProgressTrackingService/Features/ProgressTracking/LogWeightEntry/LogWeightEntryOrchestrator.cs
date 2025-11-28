using Contracts;
using FluentValidation;
using MassTransit;
using MediatR;
using ProgressTrackingService.Contracts.ProgressTracking;
using ProgressTrackingService.Database;
using ProgressTrackingService.Entities;
using ProgressTrackingService.Shared.MarkerInterface;
using Shared;
using System.Text.Json.Serialization;

namespace ProgressTrackingService.Features.ProgressTracking.LogWeightEntry;

public static class LogWeightEntryOrchestrator
{
    public record Command : ICommand<Result<LogWeightEntryResponse>>
    {
        [JsonIgnore]
        public required string UserId { get; set; }
        public required decimal Weight { get; init; }
        public required DateOnly DateRecorded { get; init; }
        public string? Notes { get; init; }
    }


    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.UserId).NotEmpty();

            RuleFor(x => x.Weight)
                .GreaterThanOrEqualTo(30).WithMessage("Weight must be at least 30kg.")
                .LessThanOrEqualTo(300).WithMessage("Weight cannot exceed 300kg.");

            RuleFor(x => x.DateRecorded)
                .Must(d => d <= DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage("Recorded date cannot be in the future.");
        }
    }

    internal sealed class Handler : IRequestHandler<Command, Result<LogWeightEntryResponse>>
    {
        private readonly Repository<WeightEntry, Guid> _weightEntryRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IValidator<Command> _validator;

        public Handler(
            Repository<WeightEntry, Guid> weightEntryRepository,
            IPublishEndpoint publishEndpoint,
            IValidator<Command> validator)
        {
            _weightEntryRepository = weightEntryRepository;
            _publishEndpoint = publishEndpoint;
            _validator = validator;
        }

        public async Task<Result<LogWeightEntryResponse>> Handle(
            Command request,
            CancellationToken cancellationToken)
        {
            
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Failure<LogWeightEntryResponse>(new Error("Validation Error in LogWeightEntryResponse ", errors.ToString()));
            }

            var entry = new WeightEntry
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Weight = request.Weight,
                DateRecorded = request.DateRecorded,
                Notes = request.Notes,
                RecordedAtUtc = DateTime.UtcNow,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow
            };

             _weightEntryRepository.Add(entry);

            await _publishEndpoint.Publish(new WeightUpdatedEvent
            {
                UserId = entry.UserId,
                NewWeight = entry.Weight,
                DateRecorded = entry.DateRecorded
            }, cancellationToken);



            // TransactionPipelineBehavior will call SaveChangesAsync()
            return Result.Success(new LogWeightEntryResponse(
                entry.Id,
                entry.Weight,
                entry.DateRecorded
            ));
        }
    }
}
