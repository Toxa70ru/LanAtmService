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
    public class GetStatussQueryHandler : IRequestHandler<GetStatussQuery, IList<GetStatusDto>>
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStatussQueryHandler(IOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<GetStatusDto>> Handle(GetStatussQuery request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.status.ToListAsync();
            var movieList = new List<GetStatusDto>();
            foreach (var movieItem in movies)
            {
                var movie = movieItem.MapTo();
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
