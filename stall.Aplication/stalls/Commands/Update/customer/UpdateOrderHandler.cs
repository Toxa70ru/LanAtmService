using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stall.Application.stalls.Queries.GetOrders;
using stall.Application.stalls.Queries.GetProducts;

namespace stall.Application.stalls.Commands.Update.customer
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrder,OrderVm>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateOrderHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<OrderVm> Handle(UpdateOrder request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.order.FirstOrDefaultAsync(order =>
                order.Order_id == request.Order_id, cancellationToken);

            if (entity == null || entity.Order_id != request.Order_id)
            {
                throw new NotFoundException();
            }

            entity.Order_id = request.Order_id;
            entity.Customer_id = request.Customer_id;
            entity.Full_name = request.Full_name;
            entity.Adres = request.Adres;
            entity.Sum = request.Sum;
            entity.Status_id = request.Status_id;
            entity.Chek_id = request.Chek_id;
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            var model = new OrderVm
            {
                Order_id = entity.Order_id,
                Customer_id = entity.Customer_id,
                Full_name = entity.Full_name,
                Adres = entity.Adres,
                Sum = entity.Sum,
                Status_id = entity.Status_id,
                Chek_id = entity.Chek_id
            };
            return model;
        }
    }
}
