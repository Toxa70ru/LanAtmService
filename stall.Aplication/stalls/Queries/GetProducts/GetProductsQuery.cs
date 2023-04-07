using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IList<GetProductDto>>
    {
    }
}
