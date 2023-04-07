using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.aithorization
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRole>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteRoleHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteRole request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.role
                .FindAsync(new object[] { request.Role_id }, cancellationToken);
            if (entity == null || entity.Role_id != request.Role_id)
            {
                throw new NotFoundException();
            }

            _dbContext.role.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteRole>.Handle(DeleteRole request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
