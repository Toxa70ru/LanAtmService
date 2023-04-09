using MediatR;
using ProductCatalog.core.Queries.DeleteManufacturers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetManufacturers
{
    public class DeleteManufacturerHandler : IRequestHandler<DeleteManufacturer,Unit>
    {
        private readonly IPCDbContext _dbContext;

        public DeleteManufacturerHandler(IPCDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteManufacturer request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.manufacturer
                .FindAsync(new object[] { request.Brend_id }, cancellationToken);
            if (entity == null || entity.Brend_id != request.Brend_id)
            {
                //throw new NotFoundException();
            }
            var id = entity.Brend_id;
            _dbContext.manufacturer.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
