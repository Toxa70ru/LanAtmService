using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public static class GetDeliverysQueryExtensions
    {
        public static GetDeliveryDto MapTo(this Delivery movie)
        {
            return new GetDeliveryDto
            {
                Delivery_id = movie.Delivery_id,
                Status_id = movie.Status_id,
                OrderInf = movie.OrderInf,
                Courier_id = movie.Courier_id
                
            };
        }
    }
}
