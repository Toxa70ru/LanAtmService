using ProductCatalog.core;
using ProductCatalog.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetManufacturers
{
    public static class GetManufacturersQueryExtensions
    {
        public static GetManufacturerDto MapTo(this Manufacturer movie)
        {
            return new GetManufacturerDto
            {
                Brend_id = movie.Brend_id,
                Brend = movie.Brend
            };
        }
    }
}
