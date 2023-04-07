using AutoMapper;
using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;

namespace stall.Application.stalls.Queries.GetOrders
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderVm>
    {
        private readonly IstallDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IstallDbContext dbContext,
            IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);
        public async Task<OrderVm> Handle(GetOrderQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.order
                .FirstOrDefaultAsync(order => order.Order_id == request.Order_id, cancellationToken);
            if (entity == null || entity.Order_id != request.Order_id)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<OrderVm>(entity);
        }
    }
}
