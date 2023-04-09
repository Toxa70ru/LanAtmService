using MediatR;
using ProductCatalog.core.Queries.GetManufacturers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.UpdateManufacturers
{
    public class UpdateManufacturer : IRequest<ManufacturerVm>
    {
        public int Brend_id { get; set; }
        public string Brend { get; set; }
    }
}
