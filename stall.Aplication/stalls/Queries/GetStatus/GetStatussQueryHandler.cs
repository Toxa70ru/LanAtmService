using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using stall.Application.interfaces;
using stall.Application.stalls.Queries.GetDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetStatus
{
    public class GetStatussQueryHandler : IRequestHandler<GetStatussQuery, IList<GetStatusDto>>
    {
        private readonly IstallDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStatussQueryHandler(IstallDbContext dbContext)
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
