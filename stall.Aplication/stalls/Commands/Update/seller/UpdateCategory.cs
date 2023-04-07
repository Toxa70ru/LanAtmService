using MediatR;
using stall.Application.stalls.Queries.GetCategorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.seller
{
    public class UpdateCategory : IRequest<CategoryVm>
    {
        public int Category_id { get; set; }
        public string Category_name { get; set; }
    }
}
