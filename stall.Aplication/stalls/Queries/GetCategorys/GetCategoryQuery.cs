using MediatR;
using stall.Application.stalls.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetCategorys
{
    public class GetCategoryQuery : IRequest<CategoryVm>
    {
        public int Category_id { get; set; }
    }
}
