using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class GetDeliveryQuery : IRequest<DeliveryVm>
    {
        public int Delivery_id { get; set; }
    }
}
