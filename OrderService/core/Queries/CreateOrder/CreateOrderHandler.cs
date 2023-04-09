using MediatR;
using OrderService.Interfaces.models;
using OrderService.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder>
    {
        private readonly IOrderDbContext _dbContext;
        public CreateOrderHandler(IOrderDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Order_id = request.Order_id,
                Customer_name = request.Customer_name,
                Full_name = request.Full_name,
                Adres = request.Adres,
                Sum = request.Sum,
                Status_id = request.Status_id
            };
            await _dbContext.order.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
