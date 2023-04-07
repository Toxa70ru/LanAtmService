using stall.Application.stalls.Queries.GetDelivery;
using stall.Domain.courier;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetManufacturers
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
