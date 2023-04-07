using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.seller
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct,Unit>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteProductHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteProduct request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.product
                .FindAsync(new object[] { request.Product_id }, cancellationToken);
            if (entity == null || entity.Product_id != request.Product_id)
            {
                throw new NotFoundException();
            }
            var id = entity.Product_id;
            _dbContext.product.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
