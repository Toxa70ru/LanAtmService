using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetDelivery
{
    public class GetDeliveryDto
    {
        public int Delivery_id { get; set; }
        public int Order_id { get; set; }
        public int Status_id { get; set; }
        public int Courier_id { get; set; }
    }
}
