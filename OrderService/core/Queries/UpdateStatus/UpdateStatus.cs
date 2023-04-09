using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class UpdateStatus : IRequest<StatusVm>
    {
        public int Status_id { get; set; }
        public string Status_name { get; set; }
    }
}
