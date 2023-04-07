using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.authorization
{
    public class UpdateRole : IRequest
    {
        public int Role_id { get; set; }
        public string Classification { get; set; }
    }
}
