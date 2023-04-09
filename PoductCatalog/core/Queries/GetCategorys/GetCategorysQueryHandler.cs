using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.core;
using ProductCatalog.core.Queries.GetCategorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetCategorys
{
    public class GetCategorysQueryHandler : IRequestHandler<GetCategorysQuery, IList<GetCategoryDto>>
    {
        private readonly IPCDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategorysQueryHandler(IPCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<GetCategoryDto>> Handle(GetCategorysQuery request, CancellationToken cancellationToken)
        {
            var cat = await _dbContext.category.ToListAsync();
            var movieList = new List<GetCategoryDto>();
            foreach (var movieItem in cat)
            {
                var movie = movieItem.MapTo();
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
