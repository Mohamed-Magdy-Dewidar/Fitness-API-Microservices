using Contracts;
using FluentValidation;
using MassTransit;
using MediatR;
using ProgressTrackingService.Contracts.ProgressTracking;
using ProgressTrackingService.Database;
using ProgressTrackingService.Entities;
using ProgressTrackingService.Shared.MarkerInterface;
using Shared;

namespace ProgressTrackingService.Features.ProgressTracking.LogMealEntry
{
    public static class LogMealEntryOrchestrator
    {
        public record Command(string UserId) : ICommand<Result<LogMealEntryResponse>>
        {

            public Guid? RecipeId { get; init; }
            public required string MealName { get; init; }
            public required string MealType { get; init; } // e.g., "Breakfast", "Dinner"
            public required int TotalCalories { get; init; }
            public required decimal Protein { get; init; }
            public required decimal Carbs { get; init; }
            public required decimal Fats { get; init; }
            public string? Notes { get; init; }
        }

       

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.UserId).NotEmpty();
                RuleFor(x => x.MealName).NotEmpty().MaximumLength(200);
                RuleFor(x => x.TotalCalories).GreaterThanOrEqualTo(0);
                RuleFor(x => x.Protein).GreaterThanOrEqualTo(0);
                RuleFor(x => x.Carbs).GreaterThanOrEqualTo(0);
                RuleFor(x => x.Fats).GreaterThanOrEqualTo(0);
            }
        }

        internal sealed class Handler : IRequestHandler<Command, Result<LogMealEntryResponse>>
        {
            private readonly Repository<NutritionLog, Guid> _nutritionLogRepo;
            private readonly IPublishEndpoint _publishEndpoint;

            public Handler(Repository<NutritionLog, Guid> nutritionLogRepo, IPublishEndpoint publishEndpoint)
            {
                _nutritionLogRepo = nutritionLogRepo;
                _publishEndpoint = publishEndpoint;
            }

            public async Task<Result<LogMealEntryResponse>> Handle(Command request, CancellationToken cancellationToken)
            {
                var entry = new NutritionLog
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId,
                    RecipeId = request.RecipeId,
                    MealName = request.MealName,
                    MealType = request.MealType,
                    TotalCalories = request.TotalCalories,
                    Protein = request.Protein,
                    Carbs = request.Carbs,
                    Fats = request.Fats,
                    Notes = request.Notes,
                    LoggedAtUtc = DateTime.UtcNow,
                    CreatedOnUtc = DateTime.UtcNow,
                    UpdatedOnUtc = DateTime.UtcNow
                };

               
                 _nutritionLogRepo.Add(entry);

                await _publishEndpoint.Publish(new MealLoggedEvent
                {
                    LogId = entry.Id,
                    UserId = entry.UserId,
                    TotalCalories = entry.TotalCalories,
                    Protein = entry.Protein,
                    Carbs = entry.Carbs,
                    Fats = entry.Fats,
                    LoggedAtUtc = entry.LoggedAtUtc
                }, cancellationToken);


                // SaveChangesAsync() is called by the TransactionPipelineBehavior
                return Result.Success(new LogMealEntryResponse(entry.Id, entry.MealName));
            }
        }
    }
}