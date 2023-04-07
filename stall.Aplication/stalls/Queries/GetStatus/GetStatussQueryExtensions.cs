using stall.Application.stalls.Queries.GetDelivery;
using stall.Domain.courier;
using stall.Domain.customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetStatus
{
    public static class GetStatussQueryExtensions
    {
        public static GetStatusDto MapTo(this Status movie)
        {
            return new GetStatusDto
            {
                Status_id = movie.Status_id,
                Status_name = movie.Status_name
            };
        }
    }
}
