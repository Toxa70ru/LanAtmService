using System;
using MediatR;

namespace stall.Application.stalls.Commands.Create.seller
{
    public class CreateCategory : IRequest
    {
        public int Category_id { get; set; }
        public string Category_name { get; set; }
    }
}
