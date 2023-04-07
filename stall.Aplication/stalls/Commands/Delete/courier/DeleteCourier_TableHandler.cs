using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using stall.Application.stalls.Commands.Delete.courier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.courier
{
    public class DeleteCourier_TableHandler : IRequestHandler<DeleteCourier_Table>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteCourier_TableHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteCourier_Table request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.courier_Table
                .FindAsync(new object[] { request.Courier_id }, cancellationToken);
            if (entity == null || entity.Courier_id != request.Courier_id)
            {
                throw new NotFoundException();
            }

            _dbContext.courier_Table.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteCourier_Table>.Handle(DeleteCourier_Table request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
