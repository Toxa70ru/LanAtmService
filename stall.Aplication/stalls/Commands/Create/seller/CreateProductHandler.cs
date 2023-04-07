using MediatR;
using Microsoft.EntityFrameworkCore;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.seller
{
    public class CreateProductHandler : IRequestHandler<CreateProduct>
    {
        private readonly IstallDbContext _dbContext;
        public CreateProductHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new NotFoundException();
            }
            var prod = new Product
            {
                Product_id = request.Product_id,
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
