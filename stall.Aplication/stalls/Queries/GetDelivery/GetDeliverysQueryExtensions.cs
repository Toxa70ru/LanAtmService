using stall.Application.stalls.Queries.GetProducts;
using stall.Domain.courier;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetDelivery
{
    public static class GetDeliverysQueryExtensions
    {
        public static GetDeliveryDto MapTo(this Delivery movie)
        {
            return new GetDeliveryDto
            {
                Delivery_id = movie.Delivery_id,
                Status_id = movie.Status_id,
                Order_id = movie.Order_id,
                Courier_id = movie.Courier_id
                
            };
        }
    }
}
