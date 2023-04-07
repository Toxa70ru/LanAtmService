using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.customer
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrder,Unit>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteOrderHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteOrder request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.order
                .FindAsync(new object[] { request.Order_id }, cancellationToken);
            if (entity == null || entity.Order_id != request.Order_id)
            {
                throw new NotFoundException();
            }
            var id = entity.Order_id;
            _dbContext.order.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
