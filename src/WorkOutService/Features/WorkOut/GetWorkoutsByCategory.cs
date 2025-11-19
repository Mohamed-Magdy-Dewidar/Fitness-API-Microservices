using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;
using WorkOutService.Contracts;
using WorkOutService.Database;
using WorkOutService.Entities;

namespace WorkOutService.Features.WorkOut;

public static class GetWorkoutsByCategory
{
    public record Query(string CategoryName) : IRequest<Result<IEnumerable<GetWorkoutByCategoryResponse>>>;

    internal sealed class Handler: IRequestHandler<Query, Result<IEnumerable<GetWorkoutByCategoryResponse>>>
    {
        private readonly Repository<Workout, Guid> _workOutRepository;

        public Handler(Repository<Workout, Guid> workOutRepository)
        {
            _workOutRepository = workOutRepository;
        }

        public async Task<Result<IEnumerable<GetWorkoutByCategoryResponse>>> Handle(Query request,CancellationToken cancellationToken)
        {
            var workouts = await _workOutRepository
              .GetAll(w => w.Category.ToLower().Contains(request.CategoryName.ToLower()))
              .Select(workout => new GetWorkoutByCategoryResponse(
                  workout.Id,
                  workout.Name,
                  workout.Description,
                  workout.Category,
                  workout.Difficulty,
                  workout.DurationMinutes,
                  workout.ImageUrl
              ))
              .ToListAsync(cancellationToken);

            if (!workouts.Any() || workouts == null)
                return Result.Failure<IEnumerable<GetWorkoutByCategoryResponse>>(new Error("Workout.NotFound", $"No workouts found for category '{request.CategoryName}'.")                );

            
             return Result.Success<IEnumerable<GetWorkoutByCategoryResponse>>(workouts);
        }
    }
}
