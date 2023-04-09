using MediatR;
using ProductCatalog.core.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetManufacturers
{
    public class GetManufacturerQuery : IRequest<ManufacturerVm>
    {
        public int Brend_id { get; set; }
    }
}
