using MediatR;
using stall.Application.interfaces;
using stall.Domain.authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.authorization
{
    public class CreateRoleHandler : IRequestHandler<CreateRole>
    {
        private readonly IstallDbContext _dbContext;
        public CreateRoleHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateRole request, CancellationToken cancellationToken)
        {
            var role = new Role
            {
                Role_id = request.Role_id,
                Classification = request.Classification
            };
            await _dbContext.role.AddAsync(role, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
