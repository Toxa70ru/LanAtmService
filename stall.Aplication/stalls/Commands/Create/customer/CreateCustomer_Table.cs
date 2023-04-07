using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.customer
{
    public class CreateCustomer_Table : IRequest
    {
        public int Customer_id { get; set; }
        public int User_id { get; set; }
    }
}
