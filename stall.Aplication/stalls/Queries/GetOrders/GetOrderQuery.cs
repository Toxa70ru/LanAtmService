using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetOrders
{
    public class GetOrderQuery  : IRequest<OrderVm>
    {
        public int Order_id { get; set; }
    }
}
