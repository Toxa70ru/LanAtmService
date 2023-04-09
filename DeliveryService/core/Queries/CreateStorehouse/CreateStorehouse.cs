using MediatR;
using System;


namespace DeliveryService.core.Queries
{
    public class CreateStorehouse : IRequest
    {
        public int Storehouse_id { get; set; }
        public string Product_name { get; set; }
        public int Count { get; set; }
    }
}
