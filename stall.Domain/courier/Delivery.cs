using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Domain.courier
{
    public class Delivery
    {
        public int Delivery_id { get; set; }
        public int Order_id { get; set; }
        public int Status_id { get; set; }
        public int Courier_id { get; set; }
    }
}
