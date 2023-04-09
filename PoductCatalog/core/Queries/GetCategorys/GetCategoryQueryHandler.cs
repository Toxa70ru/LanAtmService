using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.core;

namespace ProductCatalog.core.Queries.GetCategorys
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryVm>
    {
        private readonly IPCDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IPCDbContext dbContext,
            IMapper mapper) => (_dbcontext,_mapper) = (dbContext,mapper);
        public async Task<CategoryVm> Handle(GetCategoryQuery request,
            CancellationToken cancellationToken)
        {
            
            var entity = await _dbcontext.category
                .FirstOrDefaultAsync(categ => categ.Category_id == request.Category_id, cancellationToken);
            if (entity == null || entity.Category_id != request.Category_id)
            {
                // TODO: Create error
                //throw new NotFoundException();
            }
            return _mapper.Map<CategoryVm>(entity);
        }
    }
}
