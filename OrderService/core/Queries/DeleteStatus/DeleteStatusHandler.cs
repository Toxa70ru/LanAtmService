using MediatR;
using OrderService.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class DeleteStatusHandler : IRequestHandler<DeleteStatus,Unit>
    {
        private readonly IOrderDbContext _dbContext;

        public DeleteStatusHandler(IOrderDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteStatus request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.status
                .FindAsync(new object[] { request.Status_id }, cancellationToken);
            if (entity == null || entity.Status_id != request.Status_id)
            {
                //throw new NotFoundException();
            }
            var id = entity.Status_id;
            _dbContext.status.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
