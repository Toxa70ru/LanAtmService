using MediatR;
using System;

namespace stall.Application.stalls.Commands.Create.seller
{
    public class CreateProduct : IRequest
    {
        public int Product_id { get; set; }
        public int Brend_id { get; set; }
        public string Product_name { get; set; }
        public string Description { get; set; }
        public string Characteristic { get; set; }
        public int Category_id { get; set; }
        public int Price { get; set; }
    }
}
