using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Delete.courier
{
    public class DeleteCourier_Table : IRequest
    {
        public int Courier_id { get; set; }
        public int User_id { get; set; }
    }
}
