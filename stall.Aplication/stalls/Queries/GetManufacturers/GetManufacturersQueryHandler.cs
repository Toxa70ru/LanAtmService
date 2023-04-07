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

namespace stall.Application.stalls.Queries.GetManufacturers
{
    public class GetManufacturersQueryHandler : IRequestHandler<GetManufacturersQuery, IList<GetManufacturerDto>>
    {
        private readonly IstallDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetManufacturersQueryHandler(IstallDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<GetManufacturerDto>> Handle(GetManufacturersQuery request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.manufacturer.ToListAsync();
            var movieList = new List<GetManufacturerDto>();
            foreach (var movieItem in movies)
            {
                var movie = movieItem.MapTo();
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
