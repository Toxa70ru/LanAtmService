using stall.Application.stalls.Queries.GetProducts;
using stall.Domain.customer;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetOrders
{
    public static class GetOrdersQueryExtensions
    {
        public static GetOrderDto MapTo(this Order movie)
        {
            return new GetOrderDto
            {
                Adres = movie.Adres,
                Chek_id = movie.Chek_id,
                Customer_id = movie.Customer_id,
                Full_name = movie.Full_name,
                Order_id = movie.Order_id,
                Status_id = movie.Status_id,
                Sum = movie.Sum
            };
        }
    }
}
