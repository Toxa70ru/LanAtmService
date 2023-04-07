using AutoMapper;
using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using stall.Application.stalls.Queries.GetProducts;
using stall.Application.stalls.Queries.GetStorehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace stall.Application.stalls.Queries.GetStorehouse
{
    public class GetStorehouseQueryHandler : IRequestHandler<GetStorehouseQuery, StorehouseVm>
    {
        private readonly IstallDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetStorehouseQueryHandler(IstallDbContext dbContext,
            IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<StorehouseVm> Handle(GetStorehouseQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.storehouse
                .FirstOrDefaultAsync(store => store.Storehouse_id == request.Storehouse_id, cancellationToken);
            if (entity == null || entity.Storehouse_id != request.Storehouse_id)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<StorehouseVm>(entity);
        }
    }
}
