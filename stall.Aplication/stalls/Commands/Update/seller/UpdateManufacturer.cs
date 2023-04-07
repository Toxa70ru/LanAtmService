﻿using MediatR;
using stall.Application.stalls.Queries.GetManufacturers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Update.seller
{
    public class UpdateManufacturer : IRequest<ManufacturerVm>
    {
        public int Brend_id { get; set; }
        public string Brend { get; set; }
    }
}
