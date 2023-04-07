using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using stall.Application.stalls.Commands.Delete.aithorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.aithorization
{
    public class DeleteReg_UserHandler : IRequestHandler<DeleteReg_User>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteReg_UserHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteReg_User request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.reg_User
                .FindAsync(new object[] { request.User_id }, cancellationToken);
            if (entity == null || entity.User_id != request.User_id)
            {
                throw new NotFoundException();
            }

            _dbContext.reg_User.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteReg_User>.Handle(DeleteReg_User request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
