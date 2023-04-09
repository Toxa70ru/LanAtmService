using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetCategorys
{
    public class GetCategorysQuery : IRequest<IList<GetCategoryDto>>
    {
    }
}
