using MediatR;
using System;


namespace stall.Application.stalls.Commands.Create.customer
{
    public class CreateOrder : IRequest
    {
        public int Order_id { get; set; }
        public int Customer_id { get; set; }
        public string Full_name { get; set; }
        public string Adres { get; set; }
        public int Sum { get; set; }
        public int Status_id { get; set; }
        public int Chek_id { get; set; }
    }
}
