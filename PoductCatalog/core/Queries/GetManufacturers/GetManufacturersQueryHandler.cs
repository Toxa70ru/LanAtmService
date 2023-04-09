using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetManufacturers
{
    public class GetManufacturersQueryHandler : IRequestHandler<GetManufacturersQuery, IList<GetManufacturerDto>>
    {
        private readonly IPCDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetManufacturersQueryHandler(IPCDbContext dbContext)
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
