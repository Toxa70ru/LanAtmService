using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class CreateDeliveryHandler : IRequestHandler<CreateDelivery>
    {
        private readonly IDeliveryDbContext _dbContext;
        public CreateDeliveryHandler(IDeliveryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateDelivery request, CancellationToken cancellationToken)
        {
            var delivery = new Delivery
            {
                Delivery_id = request.Delivery_id,
                OrderInf = request.OrderInf,
                Courier_id = request.Courier_id,
                Status_id = request.Status_id
            };
            await _dbContext.delivery.AddAsync(delivery, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
