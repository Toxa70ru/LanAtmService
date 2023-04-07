using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.aithorization
{
    public class DeleteRole : IRequest
    {
        public int Role_id { get; set; }
        public string Classification { get; set; }
    }
}
