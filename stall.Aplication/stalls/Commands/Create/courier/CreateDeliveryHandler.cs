using MediatR;
using stall.Application.interfaces;
using stall.Domain.courier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.courier
{
    public class CreateDeliveryHandler : IRequestHandler<CreateDelivery>
    {
        private readonly IstallDbContext _dbContext;
        public CreateDeliveryHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateDelivery request, CancellationToken cancellationToken)
        {
            var delivery = new Delivery
            {
                Delivery_id = request.Delivery_id,
                Order_id = request.Order_id,
                Courier_id = request.Courier_id,
                Status_id = request.Status_id
            };
            await _dbContext.delivery.AddAsync(delivery, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
