using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetCategorys
{
    public class GetCategoryQuery : IRequest<CategoryVm>
    {
        public int Category_id { get; set; }
    }
}
