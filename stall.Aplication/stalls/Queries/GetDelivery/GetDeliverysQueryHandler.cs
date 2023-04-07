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

namespace stall.Application.stalls.Queries.GetDelivery
{
    public class GetDeliverysQueryHandler : IRequestHandler<GetDeliverysQuery, IList<GetDeliveryDto>>
    {
        private readonly IstallDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDeliverysQueryHandler(IstallDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<GetDeliveryDto>> Handle(GetDeliverysQuery request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.delivery.ToListAsync();
            var movieList = new List<GetDeliveryDto>();
            foreach (var movieItem in movies)
            {
                var movie = movieItem.MapTo();
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
