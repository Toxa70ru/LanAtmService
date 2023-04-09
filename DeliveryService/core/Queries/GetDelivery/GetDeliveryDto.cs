using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class GetDeliveryDto
    {
        public int Delivery_id { get; set; }
        public string OrderInf { get; set; }
        public int Status_id { get; set; }
        public int Courier_id { get; set; }
    }
}
