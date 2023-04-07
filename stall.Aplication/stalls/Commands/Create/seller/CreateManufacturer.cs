using MediatR;
using System;


namespace stall.Application.stalls.Commands.Create.seller
{
    public class CreateManufacturer : IRequest
    {
        public int Brend_id { get; set; }
        public string Brend { get; set; }
    }
}
