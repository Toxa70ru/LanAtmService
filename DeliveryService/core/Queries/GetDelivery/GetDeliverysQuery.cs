using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class GetDeliverysQuery : IRequest<IList<GetDeliveryDto>>
    {
    }
}
