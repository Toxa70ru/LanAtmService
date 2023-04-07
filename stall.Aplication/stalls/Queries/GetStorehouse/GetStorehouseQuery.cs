using MediatR;
using stall.Application.stalls.Queries.GetStorehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetStorehouse
{
    public class GetStorehouseQuery : IRequest<StorehouseVm>
    {
        public int Storehouse_id { get; set; }
    }
}
