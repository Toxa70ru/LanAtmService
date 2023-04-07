using MediatR;
using stall.Application.stalls.Queries.GetDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.courier
{
   public class UpdateDelivery : IRequest<DeliveryVm>
    {
        public int Delivery_id { get; set; }
        public int Order_id { get; set; }
        public int Status_id { get; set; }
        public int Courier_id { get; set; }
    }
}
