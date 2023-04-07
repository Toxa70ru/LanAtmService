using AutoMapper;
using MediatR;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;
using stall.Application.Common.Exceptions;
using stall.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetProducts
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVm>
    {
        private readonly IstallDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IstallDbContext dbContext,
            IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<ProductVm> Handle(GetProductQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.product
                .FirstOrDefaultAsync(product => product.Product_id == request.Product_id, cancellationToken);
            if (entity == null || entity.Product_id != request.Product_id) 
            {
                throw new NotFoundException();
            }
            return _mapper.Map<ProductVm>(entity);
        }
    }
}
