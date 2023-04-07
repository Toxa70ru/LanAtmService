using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Domain.customer
{
    public class Order_Picking
    {
        public int Chek_id { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public int Order_id { get; set; }
    }
}
