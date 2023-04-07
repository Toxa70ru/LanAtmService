﻿using MediatR;
using stall.Application.stalls.Queries.GetOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.customer
{
    public class UpdateOrder :IRequest<OrderVm>
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