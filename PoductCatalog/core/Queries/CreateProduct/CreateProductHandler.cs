using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.core;
using ProductCatalog.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProduct>
    {
        private readonly IPCDbContext _dbContext;
        public CreateProductHandler(IPCDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                //TODO Create error
                //throw new NotFoundException();
            }
            var prod = new Product
            {
                Id = request.Id,
                Brend_id = request.Brend_id,
                Category_id = request.Category_id,
                Characteristic = request.Characteristic,
                Description = request.Description,
                Price = request.Price,
                Product_name = request.Product_name
            };
            await _dbContext.product.AddAsync(prod, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
