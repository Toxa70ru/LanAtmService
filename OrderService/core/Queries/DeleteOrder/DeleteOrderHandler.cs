using MediatR;
using OrderService.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrder,Unit>
    {
        private readonly IOrderDbContext _dbContext;

        public DeleteOrderHandler(IOrderDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteOrder request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.order
                .FindAsync(new object[] { request.Order_id }, cancellationToken);
            if (entity == null || entity.Order_id != request.Order_id)
            {
                //throw new NotFoundException();
            }
            var id = entity.Order_id;
            _dbContext.order.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
