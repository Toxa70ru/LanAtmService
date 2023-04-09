using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrder,OrderVm>
    {
        private readonly IOrderDbContext _dbContext;
        public UpdateOrderHandler(IOrderDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<OrderVm> Handle(UpdateOrder request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.order.FirstOrDefaultAsync(order =>
                order.Order_id == request.Order_id, cancellationToken);

            if (entity == null || entity.Order_id != request.Order_id)
            {
                //throw new NotFoundException();
            }

            entity.Order_id = request.Order_id;
            entity.Customer_name = request.Customer_name;
            entity.Full_name = request.Full_name;
            entity.Adres = request.Adres;
            entity.Sum = request.Sum;
            entity.Status_id = request.Status_id;
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            var model = new OrderVm
            {
                Order_id = entity.Order_id,
                Customer_name = entity.Customer_name,
                Full_name = entity.Full_name,
                Adres = entity.Adres,
                Sum = entity.Sum,
                Status_id = entity.Status_id
            };
            return model;
        }
    }
}
