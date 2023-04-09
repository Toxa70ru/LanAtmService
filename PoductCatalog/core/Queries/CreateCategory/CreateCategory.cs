using System;
using MediatR;

namespace ProductCatalog.core.Queries.CreateCategory
{
    public class CreateCategory : IRequest
    {
        public int Category_id { get; set; }
        public string Category_name { get; set; }
    }
}
