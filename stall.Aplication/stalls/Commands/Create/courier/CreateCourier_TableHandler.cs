using MediatR;
using stall.Application.interfaces;
using stall.Application.stalls.Commands.Create.customer;
using stall.Domain.courier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.courier
{
    public class CreateCourier_TableHandler : IRequestHandler<CreateCourier_Table>
    {
        private readonly IstallDbContext _dbContext;
        public CreateCourier_TableHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateCourier_Table request, CancellationToken cancellationToken)
        {
            var courier_table = new Courier_Table
            {
                Courier_id = request.Courier_id,
                User_id = request.User_id
            };
            await _dbContext.courier_Table.AddAsync(courier_table, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
