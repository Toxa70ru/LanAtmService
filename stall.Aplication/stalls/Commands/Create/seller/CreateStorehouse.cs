using MediatR;
using System;


namespace stall.Application.stalls.Commands.Create.seller
{
    public class CreateStorehouse : IRequest
    {
        public int Storehouse_id { get; set; }
        public int Product_id { get; set; }
        public int Count { get; set; }
    }
}
