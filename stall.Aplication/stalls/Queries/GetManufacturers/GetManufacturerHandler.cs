using AutoMapper;
using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using stall.Application.stalls.Queries.GetManufacturers;
using Microsoft.EntityFrameworkCore;
using stall.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Queries.GetManufacturers
{
    public class GetManufacturerHandler : IRequestHandler<GetManufacturerQuery, ManufacturerVm>
    {
        private readonly IstallDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetManufacturerHandler(IstallDbContext dbContext,
            IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper); 

        public async Task<ManufacturerVm> Handle(GetManufacturerQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.manufacturer
                .FirstOrDefaultAsync(product => product.Brend_id == request.Brend_id, cancellationToken);
            if (entity == null || entity.Brend_id != request.Brend_id)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<ManufacturerVm>(entity);
        }
    }
}
