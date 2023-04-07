using MediatR;
using stall.Application.interfaces;
using stall.Domain.customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.customer
{
    public class CreateStatusHandler : IRequestHandler<CreateStatus>
    {
        private readonly IstallDbContext _dbContext;
        public CreateStatusHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateStatus request, CancellationToken cancellationToken)
        {
            var status = new Status
            {
                Status_id = request.Status_id,
                Status_name = request.Status_name
            };
            await _dbContext.status.AddAsync(status, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
