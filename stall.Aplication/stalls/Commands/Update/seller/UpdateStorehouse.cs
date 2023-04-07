using MediatR;
using stall.Application.stalls.Queries.GetStorehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.seller
{
    public class UpdateStorehouse : IRequest<StorehouseVm>
    {
        public int Storehouse_id { get; set; }
        public int Product_id { get; set; }
        public int Count { get; set; }
    }
}
