using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.core;
using ProductCatalog.core.Queries.GetProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct,ProductVm>
    {
        private readonly IPCDbContext _dbContext;
        public UpdateProductHandler(IPCDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<ProductVm> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.product.FirstOrDefaultAsync(product =>
                product.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                //TODO Create error
                //throw new NotFoundException();
            }

            entity.Id = request.Id;
            entity.Brend_id = request.Brend_id;
            entity.Product_name = request.Product_name;
            entity.Description = request.Description;
            entity.Characteristic = request.Characteristic;
            entity.Category_id = request.Category_id;
            entity.Price = request.Price;
            await _dbContext.SaveChangesAsync(cancellationToken);

            var model = new ProductVm { Id = entity.Id,Brend_id = entity.Brend_id,Product_name = entity.Product_name,
            Description = entity.Description,Characteristic = entity.Characteristic, Category_id = entity.Category_id, Price = entity.Price}; 
            return model;
        }
    }
}
