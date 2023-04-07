using AutoMapper;
using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;
using stall.Application.stalls.Queries.GetCategorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetCategorys
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryVm>
    {
        private readonly IstallDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IstallDbContext dbContext,
            IMapper mapper) => (_dbcontext,_mapper) = (dbContext,mapper);
        public async Task<CategoryVm> Handle(GetCategoryQuery request,
            CancellationToken cancellationToken)
        {
            // TODO: Исправить ошибку потери чего-то ;)
            var entity = await _dbcontext.category
                .FirstOrDefaultAsync(categ => categ.Category_id == request.Category_id, cancellationToken);
            if (entity == null || entity.Category_id != request.Category_id)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<CategoryVm>(entity);
        }
    }
}
