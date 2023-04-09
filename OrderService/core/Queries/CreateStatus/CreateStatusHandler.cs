﻿using MediatR;
using OrderService.Interfaces.models;
using OrderService.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.core.Queries
{
    public class CreateStatusHandler : IRequestHandler<CreateStatus>
    {
        private readonly IOrderDbContext _dbContext;
        public CreateStatusHandler(IOrderDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(CreateStatus request, CancellationToken cancellationToken)
        {
            var status = new Status
            {
                Status_id = request.Status_id,
                Status_name = request.Status_name
            };
            await _dbContext.status.AddAsync(status, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}