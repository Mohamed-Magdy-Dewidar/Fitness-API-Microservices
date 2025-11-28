using MediatR;
using ProgressTrackingService.DataBase;
using ProgressTrackingService.Shared.MarkerInterface;


public static class TransactionalMiddleware
{
    public class TransactionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
        where TResponse : ProgressTrackingService.Shared.MarkerInterface.IResult
    {

        private readonly ProgressTrackingDbContext _context;

        public TransactionPipelineBehavior(ProgressTrackingDbContext context)
        {
            _context = context;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_context.Database.CurrentTransaction is not null)
                return await next();

            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var response = await next();

                if (response.IsFailure)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return response;
                }

                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return response;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}