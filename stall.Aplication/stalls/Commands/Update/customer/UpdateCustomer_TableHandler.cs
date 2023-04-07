using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using stall.Application.stalls.Commands.Update.customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.customer
{
    public class UpdateCustomer_TableHandler : IRequestHandler<UpdateCustomer_Table>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateCustomer_TableHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCustomer_Table request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.customer_Table.FirstOrDefaultAsync(custT =>
                custT.Customer_id == request.Customer_id, cancellationToken);

            if (entity == null || entity.Customer_id != request.Customer_id)
            {
                throw new NotFoundException();
            }

            entity.Customer_id = request.Customer_id;
            entity.User_id = request.User_id;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateCustomer_Table>.Handle(UpdateCustomer_Table request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
