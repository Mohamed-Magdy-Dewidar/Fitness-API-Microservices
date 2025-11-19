using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;
using WorkOutService.Contracts;
using WorkOutService.Database;
using WorkOutService.Entities;

namespace WorkOutService.Features.WorkOut;

public static class GetWorkOuts
{
    public record Query() : IRequest<Result<IEnumerable<GetWorkOutsResponse>>>; 

  

    internal sealed class Handler : IRequestHandler<Query, Result<IEnumerable<GetWorkOutsResponse>>>
    {
        private readonly Repository<Workout, Guid> _workOutRepository;
        public Handler(Repository<Workout, Guid> workOutRepository)
        {
            _workOutRepository = workOutRepository;
        }
        public  async Task<Result<IEnumerable<GetWorkOutsResponse>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var workOuts = await  _workOutRepository.GetAll()
                .Select(workout => new GetWorkOutsResponse(
                    workout.Id,
                    workout.Name,
                    workout.Description,
                    workout.Category,
                    workout.Difficulty,
                    workout.DurationMinutes,
                    workout.ImageUrl
                )).ToListAsync();

            if(workOuts == null)
                return Result.Failure<IEnumerable<GetWorkOutsResponse>>(new Error("NotFound", "No workouts found." ));


            return Result.Success<IEnumerable<GetWorkOutsResponse>>(workOuts);
        }
    }
}
