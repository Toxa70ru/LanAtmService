using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.courier
{
    public class DeleteDeliveryHandler : IRequestHandler<DeleteDelivery,Unit>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteDeliveryHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteDelivery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.delivery
                .FindAsync(new object[] { request.Delivery_id }, cancellationToken);
            if (entity == null || entity.Delivery_id != request.Delivery_id)
            {
                throw new NotFoundException();
            }
            var id = entity.Delivery_id;
            _dbContext.delivery.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
