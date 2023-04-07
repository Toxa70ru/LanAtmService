using MediatR;
using stall.Domain;
using stall.Domain.seller;
using stall.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stall.Application.stalls.Commands.Create.seller
    {
        public class CreateManufacturerHandler : IRequestHandler<CreateManufacturer>
        {
            private readonly IstallDbContext _dbContext;
            public CreateManufacturerHandler(IstallDbContext dbContext) =>
                _dbContext = dbContext;
            public async Task Handle(CreateManufacturer request, CancellationToken cancellationToken)
            {
                var manufacturer = new Manufacturer
                {
                    Brend_id = request.Brend_id,
                    Brend = request.Brend
                };
                await _dbContext.manufacturer.AddAsync(manufacturer, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return;
            }
        }
    }

