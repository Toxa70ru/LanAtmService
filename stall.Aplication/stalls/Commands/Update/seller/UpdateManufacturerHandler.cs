using MediatR;
using stall.Application.Common.Exceptions;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;
using stall.Domain.seller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stall.Application.stalls.Queries.GetManufacturers;

namespace stall.Application.stalls.Commands.Update.seller
{
    public class UpdateManufacturerHandler : IRequestHandler<UpdateManufacturer,ManufacturerVm>
    {
        private readonly IstallDbContext _dbContext;
        public UpdateManufacturerHandler(IstallDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<ManufacturerVm> Handle(UpdateManufacturer request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.manufacturer.FirstOrDefaultAsync(brend =>
                brend.Brend_id == request.Brend_id, cancellationToken);

            if (entity == null || entity.Brend_id != request.Brend_id)
            {
                throw new NotFoundException();
            }

            entity.Brend_id = request.Brend_id;
            entity.Brend = request.Brend;
            await _dbContext.SaveChangesAsync(cancellationToken);

            var model = new ManufacturerVm { Brend_id = entity.Brend_id,Brend = entity.Brend}; 
            return model;
        }
    }
}
