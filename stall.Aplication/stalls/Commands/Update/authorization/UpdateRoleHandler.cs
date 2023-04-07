using MediatR;
using Microsoft.EntityFrameworkCore;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.authorization
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRole>
    {

            private readonly IstallDbContext _dbContext;
            public UpdateRoleHandler(IstallDbContext dbContext) =>
                _dbContext = dbContext;

            public async Task<Unit> Handle(UpdateRole request, CancellationToken cancellationToken)
            {
                var entity =
                    await _dbContext.role.FirstOrDefaultAsync(role =>
                    role.Role_id == request.Role_id, cancellationToken);

                if (entity == null || entity.Role_id != request.Role_id)
                {
                    throw new NotFoundException();
                }

                entity.Role_id = request.Role_id;
                entity.Classification = request.Classification;
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            Task IRequestHandler<UpdateRole>.Handle(UpdateRole request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
       
    }
}

