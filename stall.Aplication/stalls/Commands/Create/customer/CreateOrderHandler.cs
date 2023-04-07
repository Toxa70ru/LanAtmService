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
    public class CreateOrderHandler : IRequestHandler<CreateOrder>
    {
        private readonly IstallDbContext _dbContext;
        public CreateOrderHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Order_id = request.Order_id,
                Customer_id = request.Customer_id,
                Full_name = request.Full_name,
                Adres = request.Adres,
                Sum = request.Sum,
                Chek_id = request.Chek_id,
                Status_id = request.Status_id
            };
            await _dbContext.order.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
