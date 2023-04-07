using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.customer
{
    public class DeleteStatusHandler : IRequestHandler<DeleteStatus,Unit>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteStatusHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteStatus request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.status
                .FindAsync(new object[] { request.Status_id }, cancellationToken);
            if (entity == null || entity.Status_id != request.Status_id)
            {
                throw new NotFoundException();
            }
            var id = entity.Status_id;
            _dbContext.status.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
