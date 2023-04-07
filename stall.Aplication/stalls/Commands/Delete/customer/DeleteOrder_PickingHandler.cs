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
    public class DeleteOrder_PickingHandler : IRequestHandler<DeleteOrder_Picking>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteOrder_PickingHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteOrder_Picking request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.order_Picking
                .FindAsync(new object[] { request.Chek_id }, cancellationToken);
            if (entity == null || entity.Chek_id != request.Chek_id)
            {
                throw new NotFoundException();
            }

            _dbContext.order_Picking.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteOrder_Picking>.Handle(DeleteOrder_Picking request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
