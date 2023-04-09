using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public static class GetStorehousesQueryExtensions
    {
        public static StorehouseDto MapTo(this Storehouse movie)
        {
            return new StorehouseDto
            {
                Storehouse_id = movie.Storehouse_id,
                Product_name = movie.Product_name,
                Count = movie.Count
            };
        }
    }
}
