using MediatR;
using stall.Application.stalls.Queries.GetDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetStatus
{
    public class GetStatussQuery : IRequest<IList<GetStatusDto>>
    {
    }
}
