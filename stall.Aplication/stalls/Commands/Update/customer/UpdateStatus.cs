using MediatR;
using stall.Application.stalls.Queries.GetStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.customer
{
    public class UpdateStatus : IRequest<StatusVm>
    {
        public int Status_id { get; set; }
        public string Status_name { get; set; }
    }
}
