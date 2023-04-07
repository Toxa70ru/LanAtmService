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

namespace stall.Application.stalls.Queries.GetCategorys
{
    public class GetCategorysQueryHandler : IRequestHandler<GetCategorysQuery, IList<GetCategoryDto>>
    {
        private readonly IstallDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategorysQueryHandler(IstallDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<GetCategoryDto>> Handle(GetCategorysQuery request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.category.ToListAsync();
            var movieList = new List<GetCategoryDto>();
            foreach (var movieItem in movies)
            {
                var movie = movieItem.MapTo();
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
