using OrderService.Interfaces.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
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
