﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.seller
{
    public class DeleteManufacturer : IRequest<Unit>
    {
        public int Brend_id { get; set; }
        //public string Brend { get; set; }
    }
}
