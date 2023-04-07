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

namespace stall.Application.stalls.Queries.GetStorehouse
{
    public class GetStorehousesQueryHandler : IRequestHandler<GetStorehousesQuery, IList<StorehouseDto>>
    {
        private readonly IstallDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStorehousesQueryHandler(IstallDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<StorehouseDto>> Handle(GetStorehousesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.storehouse.ToListAsync();
            var movieList = new List<StorehouseDto>();
            foreach (var movieItem in movies)
            {
                var movie = movieItem.MapTo();
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
