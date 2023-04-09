using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.core.Queries
{
    public class GetDeliveryQueryHandler : IRequestHandler<GetDeliveryQuery, DeliveryVm>
    {
        private readonly IDeliveryDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetDeliveryQueryHandler(IDeliveryDbContext dbContext,
            IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<DeliveryVm> Handle(GetDeliveryQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.delivery
                .FirstOrDefaultAsync(del => del.Delivery_id == request.Delivery_id, cancellationToken);
            if (entity == null || entity.Delivery_id != request.Delivery_id)
            {
                //throw new NotFoundException();
            }
            return _mapper.Map<DeliveryVm>(entity);
        }
    }
}
