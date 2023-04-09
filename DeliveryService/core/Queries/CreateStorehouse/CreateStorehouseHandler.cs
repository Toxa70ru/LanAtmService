using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class CreateStorehouseHandler : IRequestHandler<CreateStorehouse>
    {
        private readonly IDeliveryDbContext _dbContext;
        public CreateStorehouseHandler(IDeliveryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateStorehouse request, CancellationToken cancellationToken)
        {
            var storehouse = new Storehouse
            {
                Count = request.Count,
                Product_name = request.Product_name,
                Storehouse_id = request.Storehouse_id
            };
            await _dbContext.storehouse.AddAsync(storehouse, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
