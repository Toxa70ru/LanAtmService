using ProductCatalog.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetCategorys
{
    public static class GetCategorysQueryExtensions
    {
        public static GetCategoryDto MapTo(this Category cat)
        {
            return new GetCategoryDto
            {
                Category_id = cat.Category_id,
                Category_name = cat.Category_name
            };
        }
    }
}
