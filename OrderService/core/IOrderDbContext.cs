using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OrderService.Interfaces.models;

namespace OrderService.core
{
    public interface IOrderDbContext
    {
        public DbSet<Order> order { get; set; }
        public DbSet<Status> status { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
