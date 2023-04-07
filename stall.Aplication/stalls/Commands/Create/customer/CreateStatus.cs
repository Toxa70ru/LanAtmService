using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.customer
{
    public class CreateStatus : IRequest
    {
        public int Status_id { get; set; }
        public string Status_name { get; set; }
    }
}
