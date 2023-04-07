using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.customer
{
    public class UpdateOrder_PickingHandler : IRequestHandler<UpdateOrder_Picking>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateOrder_PickingHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateOrder_Picking request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.order_Picking.FirstOrDefaultAsync(orderP =>
                orderP.Chek_id == request.Chek_id, cancellationToken);

            if (entity == null || entity.Chek_id != request.Chek_id)
            {
                throw new NotFoundException();
            }

            entity.Chek_id = request.Chek_id;
            entity.Product = request.Product;
            entity.Count = request.Count;
            entity.Order_id = request.Order_id;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateOrder_Picking>.Handle(UpdateOrder_Picking request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
