using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stall.Application.stalls.Queries.GetStatus;
using stall.Application.stalls.Queries.GetOrders;

namespace stall.Application.stalls.Commands.Update.customer
{
    public class UpdateStatusHandler : IRequestHandler<UpdateStatus,StatusVm>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateStatusHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<StatusVm> Handle(UpdateStatus request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.status.FirstOrDefaultAsync(status =>
                status.Status_id == request.Status_id, cancellationToken);

            if (entity == null || entity.Status_id != request.Status_id)
            {
                throw new NotFoundException();
            }

            entity.Status_id = request.Status_id;
            entity.Status_name = request.Status_name;
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            var model = new StatusVm
            {
                Status_id = entity.Status_id,
                Status_name = entity.Status_name
            };
            return model;
        }
    }
}
