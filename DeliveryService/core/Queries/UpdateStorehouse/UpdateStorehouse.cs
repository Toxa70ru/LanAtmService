using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class UpdateStorehouse : IRequest<StorehouseVm>
    {
        public int Storehouse_id { get; set; }
        public string Product_name { get; set; }
        public int Count { get; set; }
    }
}
