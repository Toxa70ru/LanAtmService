using MediatR;
using ProductCatalog.core.Queries.GetProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.UpdateProduct
{
    public class UpdateProduct : IRequest<ProductVm>
    {
        public int Id { get; set; }
        public int Brend_id { get; set; }
        public string Product_name { get; set; }
        public string Description { get; set; }
        public string Characteristic { get; set; }
        public int Category_id { get; set; }
        public int Price { get; set; }
    }
}
