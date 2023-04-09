using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class GetOrderDto
    {
        public int Order_id { get; set; }
        public string Customer_name { get; set; }
        public string Full_name { get; set; }
        public string Adres { get; set; }
        public int Sum { get; set; }
        public int Status_id { get; set; }
    }
}
