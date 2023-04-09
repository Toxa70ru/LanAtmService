using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVm>
    {
        private readonly IPCDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IPCDbContext dbContext,
            IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<ProductVm> Handle(GetProductQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.product
                .FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id) 
            {
                //TODO Доделать выброс ошибки
            }
            return _mapper.Map<ProductVm>(entity);
        }
    }
}
