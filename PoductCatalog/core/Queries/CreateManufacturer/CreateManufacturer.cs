using MediatR;
using System;


namespace ProductCatalog.core.Queries.GetManufacturers
{
    public class CreateManufacturer : IRequest
    {
        public int Brend_id { get; set; }
        public string Brend { get; set; }
    }
}
