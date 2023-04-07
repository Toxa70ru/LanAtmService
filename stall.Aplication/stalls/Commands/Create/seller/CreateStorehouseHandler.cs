using MediatR;
using stall.Application.interfaces;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.seller
{
    public class CreateStorehouseHandler : IRequestHandler<CreateStorehouse>
    {
        private readonly IstallDbContext _dbContext;
        public CreateStorehouseHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateStorehouse request, CancellationToken cancellationToken)
        {
            var storehouse = new Storehouse
            {
                Count = request.Count,
                Product_id = request.Product_id,
                Storehouse_id = request.Storehouse_id
            };
            await _dbContext.storehouse.AddAsync(storehouse, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
