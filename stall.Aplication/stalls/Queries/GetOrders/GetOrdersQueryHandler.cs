using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using stall.Application.interfaces;
using stall.Application.stalls.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IList<GetOrderDto>>
    {
        private readonly IstallDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IstallDbContext dbContext)
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
