using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.core.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IList<GetProductDto>>
    {
        private readonly IPCDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IPCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<GetProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.product.ToListAsync();
            var movieList = new List<GetProductDto>();
            foreach (var movieItem in movies)
            {
                var movie = movieItem.MapTo();
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
