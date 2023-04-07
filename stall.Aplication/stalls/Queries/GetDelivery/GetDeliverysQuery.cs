using MediatR;
using stall.Application.stalls.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetDelivery
{
    public class GetDeliverysQuery : IRequest<IList<GetDeliveryDto>>
    {
    }
}
