using MediatR;
using stall.Application.stalls.Queries.GetDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetStatus
{
    public class GetStatusQuery : IRequest<StatusVm>
    {
        public int Status_id { get; set; }
    }
}
