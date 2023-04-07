using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.seller
{
    public class DeleteCategory : IRequest<Unit>
    {
        public int Category_id { get; set; }
        //public string Category_name { get; set; }
    }
}
