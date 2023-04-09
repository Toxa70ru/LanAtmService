using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IList<GetOrderDto>>
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<GetOrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.order.ToListAsync();
            var movieList = new List<GetOrderDto>();
            foreach (var movieItem in movies)
            {
                var movie = movieItem.MapTo();
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
