using MediatR;
using stall.Application.interfaces;
using stall.Application.stalls.Commands.Create.seller;
using stall.Domain.customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.customer
{
    public class CreateCustomer_TableHandler : IRequestHandler<CreateCustomer_Table>
    {
        private readonly IstallDbContext _dbContext;
        public CreateCustomer_TableHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateCustomer_Table request, CancellationToken cancellationToken)
        {
            var customer_table = new Customer_Table
            {
                Customer_id = request.Customer_id, 
                User_id = request.User_id 
            };
            await _dbContext.customer_Table.AddAsync(customer_table, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
