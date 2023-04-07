using stall.Application.stalls.Queries.GetProducts;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetCategorys
{
    public static class GetCategorysQueryExtensions
    {
        public static GetCategoryDto MapTo(this Category movie)
        {
            return new GetCategoryDto
            {
                Category_id = movie.Category_id,
                Category_name = movie.Category_name
            };
        }
    }
}
