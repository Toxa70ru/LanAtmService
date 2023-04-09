using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.DeleteProduct
{
    public class DeleteProduct : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
