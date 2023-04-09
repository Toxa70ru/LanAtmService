using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class DeleteStorehouseHandler : IRequestHandler<DeleteStorehouse,Unit>
    {
        private readonly IDeliveryDbContext _dbContext;

        public DeleteStorehouseHandler(IDeliveryDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteStorehouse request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.storehouse
                .FindAsync(new object[] { request.Storehouse_id }, cancellationToken);
            if (entity == null || entity.Storehouse_id != request.Storehouse_id)
            {
                //throw new NotFoundException();
            }
            var id = entity.Storehouse_id;
            _dbContext.storehouse.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
