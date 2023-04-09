using MediatR;
using System;

namespace ProductCatalog.core.Queries.CreateProduct
{
    public class CreateProduct : IRequest
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
