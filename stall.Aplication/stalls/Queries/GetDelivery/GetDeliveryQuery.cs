using MediatR;
using stall.Application.stalls.Queries.GetDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetDelivery
{
    public class GetDeliveryQuery : IRequest<DeliveryVm>
    {
        public int Delivery_id { get; set; }
    }
}
