using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stall.Application.stalls.Queries.GetDelivery;
using stall.Application.stalls.Queries.GetProducts;

namespace stall.Application.stalls.Commands.Update.courier
{
    public class UpdateDeliveryHandler : IRequestHandler<UpdateDelivery,DeliveryVm>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateDeliveryHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<DeliveryVm> Handle(UpdateDelivery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.delivery.FirstOrDefaultAsync(deliver =>
                deliver.Delivery_id == request.Delivery_id, cancellationToken);

            if (entity == null || entity.Delivery_id != request.Delivery_id)
            {
                throw new NotFoundException();
            }

            entity.Delivery_id = request.Delivery_id;
            entity.Order_id = request.Order_id;
            entity.Status_id = request.Status_id;
            entity.Courier_id = request.Courier_id;

            await _dbContext.SaveChangesAsync(cancellationToken);
            var model = new DeliveryVm
            {
                Delivery_id = entity.Delivery_id,
                Order_id = entity.Order_id,
                Status_id = entity.Status_id,
                Courier_id = entity.Courier_id
            };
            return model;
        }
    }
}
