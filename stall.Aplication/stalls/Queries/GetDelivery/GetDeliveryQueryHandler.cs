using AutoMapper;
using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;
using stall.Application.stalls.Queries.GetDelivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetDelivery
{
    public class GetDeliveryQueryHandler : IRequestHandler<GetDeliveryQuery, DeliveryVm>
    {
        private readonly IstallDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetDeliveryQueryHandler(IstallDbContext dbContext,
            IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<DeliveryVm> Handle(GetDeliveryQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.delivery
                .FirstOrDefaultAsync(del => del.Delivery_id == request.Delivery_id, cancellationToken);
            if (entity == null || entity.Delivery_id != request.Delivery_id)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<DeliveryVm>(entity);
        }
    }
}
