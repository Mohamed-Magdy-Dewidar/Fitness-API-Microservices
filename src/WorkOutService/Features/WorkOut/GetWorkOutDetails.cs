using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;
using WorkOutService.Contracts;
using WorkOutService.Database;
using WorkOutService.Entities;

namespace WorkOutService.Features.WorkOut;

public static class GetWorkOutDetails
{
    public record Query(Guid Id) : IRequest<Result<GetWorkOutDetailsResponse>>;

    internal sealed class Handler : IRequestHandler<Query, Result<GetWorkOutDetailsResponse>>
    {
        private readonly Repository<Workout, Guid> _workOutRepository;

        public Handler(Repository<Workout, Guid> workOutRepository)
        {
            _workOutRepository = workOutRepository;
        }

        public async Task<Result<GetWorkOutDetailsResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var workout = await _workOutRepository.FindByCondition(w => w.Id == request.Id)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(cancellationToken);

            
            if (workout == null)
            {
                return Result.Failure<GetWorkOutDetailsResponse>( new Error("RES_WORKOUT_NOT_FOUND", $"The workout with Id {request.Id} was not found."));
            }


            var exerciseDetails = workout.WorkoutExercises
                .OrderBy(we => we.Order) 
                .Select(we => new ExerciseDetailDto(
                    we.ExerciseId, 
                    we.Exercise.Name,
                    we.Order,
                    we.Sets,
                    we.Reps,
                    we.RestTimeSeconds,
                    we.Instructions ?? we.Exercise.Instructions ?? "", 
                    we.Exercise.TargetMuscleGroup,
                    we.Exercise.VideoUrl
                )).ToList();

            var response = new GetWorkOutDetailsResponse(
                workout.Id,
                workout.Name,
                workout.Description,
                workout.Category,
                workout.Difficulty,
                workout.DurationMinutes,
                workout.EstimatedCaloriesBurn,
                workout.ImageUrl,
                workout.AverageRating,
                workout.TotalRatings,
                exerciseDetails
            );

            return Result.Success(response);
        }
    }
}
