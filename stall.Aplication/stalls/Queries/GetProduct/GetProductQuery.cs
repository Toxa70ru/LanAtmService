using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetProducts
{
    public class GetProductQuery : IRequest<ProductVm>
    {
        public int Product_id { get; set; }

    }
}
