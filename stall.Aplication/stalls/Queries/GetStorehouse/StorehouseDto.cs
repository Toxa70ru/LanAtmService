using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetStorehouse
{
    public class StorehouseDto
    {
        public int Storehouse_id { get; set; }
        public int Product_id { get; set; }
        public int Count { get; set; }
    }
}
