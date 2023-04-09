using MediatR;
using ProductCatalog.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct,Unit>
    {
        private readonly IPCDbContext _dbContext;

        public DeleteProductHandler(IPCDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteProduct request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.product
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                //TODO Create error
                //throw new NotFoundException();
            }
            var id = entity.Id;
            _dbContext.product.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
