using stall.Application.stalls.Queries.GetProducts;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetStorehouse
{
    public static class GetStorehousesQueryExtensions
    {
        public static StorehouseDto MapTo(this Storehouse movie)
        {
            return new StorehouseDto
            {
                Storehouse_id = movie.Storehouse_id,
                Product_id = movie.Product_id,
                Count = movie.Count
            };
        }
    }
}
