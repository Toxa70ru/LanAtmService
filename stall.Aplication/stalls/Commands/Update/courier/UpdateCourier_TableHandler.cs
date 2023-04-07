using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.courier
{
    public class UpdateCourier_TableHandler : IRequestHandler<UpdateCourier_Table>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateCourier_TableHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCourier_Table request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.courier_Table.FirstOrDefaultAsync(courT =>
                courT.Courier_id == request.Courier_id, cancellationToken);

            if (entity == null || entity.Courier_id != request.Courier_id)
            {
                throw new NotFoundException();
            }

            entity.Courier_id = request.Courier_id;
            entity.User_id = request.User_id;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateCourier_Table>.Handle(UpdateCourier_Table request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
