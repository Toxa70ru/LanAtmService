using OrderService.Interfaces.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public static class GetOrdersQueryExtensions
    {
        public static GetOrderDto MapTo(this Order movie)
        {
            return new GetOrderDto
            {
                Adres = movie.Adres,
                Customer_name = movie.Customer_name,
                Full_name = movie.Full_name,
                Order_id = movie.Order_id,
                Status_id = movie.Status_id,
                Sum = movie.Sum
            };
        }
    }
}
