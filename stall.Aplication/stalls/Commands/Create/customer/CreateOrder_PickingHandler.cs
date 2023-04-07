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
    public class CreateOrder_PickingHandler : IRequestHandler<CreateOrder_Picking>
    {
        private readonly IstallDbContext _dbContext;
        public CreateOrder_PickingHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateOrder_Picking request, CancellationToken cancellationToken)
        {
            var order_picking = new Order_Picking
            {
                Chek_id = request.Chek_id,
                Product = request.Product,
                Count = request.Count,
                Order_id = request.Order_id
            };
            await _dbContext.order_Picking.AddAsync(order_picking, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
