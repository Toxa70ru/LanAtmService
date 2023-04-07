using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stall.Application.stalls.Queries.GetStorehouse;

namespace stall.Application.stalls.Commands.Update.seller
{
    public class UpdateStorehouseHandler : IRequestHandler<UpdateStorehouse,StorehouseVm>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateStorehouseHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<StorehouseVm> Handle(UpdateStorehouse request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.storehouse.FirstOrDefaultAsync(store =>
                store.Storehouse_id == request.Storehouse_id, cancellationToken);

            if (entity == null || entity.Storehouse_id != request.Storehouse_id)
            {
                throw new NotFoundException();
            }

            entity.Storehouse_id = request.Storehouse_id;
            entity.Product_id = request.Product_id;
            entity.Count = request.Count;
            await _dbContext.SaveChangesAsync(cancellationToken);
            var model = new StorehouseVm { Storehouse_id = entity.Storehouse_id, Product_id = entity.Product_id, Count = entity.Count };
            return model;
        }
    }
}
