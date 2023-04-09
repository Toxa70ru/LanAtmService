using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class GetStatussQuery : IRequest<IList<GetStatusDto>>
    {
    }
}
