using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Domain.seller
{
    public class Storehouse
    {
        public int Storehouse_id { get; set; }
        public int Product_id { get; set; }
        public int Count { get; set; }
    }
}
