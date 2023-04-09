using MediatR;
using ProductCatalog.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.core.Queries.GetManufacturers
    {
        public class CreateManufacturerHandler : IRequestHandler<CreateManufacturer>
        {
            private readonly IPCDbContext _dbContext;
            public CreateManufacturerHandler(IPCDbContext dbContext) =>
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

