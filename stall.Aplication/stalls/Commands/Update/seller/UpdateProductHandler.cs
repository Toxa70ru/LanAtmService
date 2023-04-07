using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using stall.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stall.Application.stalls.Queries.GetProducts;

namespace stall.Application.stalls.Commands.Update.seller
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct,ProductVm>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateProductHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<ProductVm> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.product.FirstOrDefaultAsync(product =>
                product.Product_id == request.Product_id, cancellationToken);

            if (entity == null || entity.Product_id != request.Product_id)
            {
                throw new NotFoundException();
            }

            entity.Product_id = request.Product_id;
            entity.Brend_id = request.Brend_id;
            entity.Product_name = request.Product_name;
            entity.Description = request.Description;
            entity.Characteristic = request.Characteristic;
            entity.Category_id = request.Category_id;
            entity.Price = request.Price;
            await _dbContext.SaveChangesAsync(cancellationToken);

            var model = new ProductVm { Product_id = entity.Product_id,Brend_id = entity.Brend_id,Product_name = entity.Product_name,
            Description = entity.Description,Characteristic = entity.Characteristic, Category_id = entity.Category_id, Price = entity.Price}; 
            return model;
        }
    }
}
