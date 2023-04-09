using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class UpdateStorehouseHandler : IRequestHandler<UpdateStorehouse,StorehouseVm>
    {
        private readonly IDeliveryDbContext _dbContext;
        public UpdateStorehouseHandler(IDeliveryDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<StorehouseVm> Handle(UpdateStorehouse request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.storehouse.FirstOrDefaultAsync(store =>
                store.Storehouse_id == request.Storehouse_id, cancellationToken);

            if (entity == null || entity.Storehouse_id != request.Storehouse_id)
            {
                //throw new NotFoundException();
            }

            entity.Storehouse_id = request.Storehouse_id;
            entity.Product_name = request.Product_name;
            entity.Count = request.Count;
            await _dbContext.SaveChangesAsync(cancellationToken);
            var model = new StorehouseVm { Storehouse_id = entity.Storehouse_id, Product_name = entity.Product_name, Count = entity.Count };
            return model;
        }
    }
}
