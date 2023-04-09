using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, StatusVm>
    {
        private readonly IOrderDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetStatusQueryHandler(IOrderDbContext dbContext,
            IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<StatusVm> Handle(GetStatusQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.status
                .FirstOrDefaultAsync(del => del.Status_id == request.Status_id, cancellationToken);
            if (entity == null || entity.Status_id != request.Status_id)
            {
                //throw new NotFoundException();
            }
            return _mapper.Map<StatusVm>(entity);
        }
    }
}
