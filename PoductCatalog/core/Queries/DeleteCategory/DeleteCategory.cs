using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.DeleteCategory
{
    public class DeleteCategory : IRequest<Unit>
    {
        public int Category_id { get; set; }
    }
}
