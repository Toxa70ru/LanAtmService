using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.customer
{
    public class DeleteStatus : IRequest<Unit>
    {
        public int Status_id { get; set; }
        
    }
}
