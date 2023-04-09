using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductVm>
    {
        public int Id { get; set; }

    }
}
