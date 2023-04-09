using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.DeleteManufacturers
{
    public class DeleteManufacturer : IRequest<Unit>
    {
        public int Brend_id { get; set; }
    }
}
