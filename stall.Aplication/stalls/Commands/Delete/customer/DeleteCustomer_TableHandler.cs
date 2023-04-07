using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using stall.Application.stalls.Commands.Delete.customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.customer
{
    public class DeleteCustomer_TableHandler : IRequestHandler<DeleteCustomer_Table>
    {
        private readonly IstallDbContext _dbContext;

        public DeleteCustomer_TableHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteCustomer_Table request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.customer_Table
                .FindAsync(new object[] { request.Customer_id }, cancellationToken);
            if (entity == null || entity.Customer_id != request.Customer_id)
            {
                throw new NotFoundException();
            }

            _dbContext.customer_Table.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteCustomer_Table>.Handle(DeleteCustomer_Table request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
