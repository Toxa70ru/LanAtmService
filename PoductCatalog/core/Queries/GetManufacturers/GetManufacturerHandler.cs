using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.core.Queries.GetManufacturers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetManufacturers
{
    public class GetManufacturerHandler : IRequestHandler<GetManufacturerQuery, ManufacturerVm>
    {
        private readonly IPCDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetManufacturerHandler(IPCDbContext dbContext,
            IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper); 

        public async Task<ManufacturerVm> Handle(GetManufacturerQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.manufacturer
                .FirstOrDefaultAsync(product => product.Brend_id == request.Brend_id, cancellationToken);
            if (entity == null || entity.Brend_id != request.Brend_id)
            {
                //throw new NotFoundException();
            }
            return _mapper.Map<ManufacturerVm>(entity);
        }
    }
}
