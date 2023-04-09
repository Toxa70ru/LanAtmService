using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DeliveryService.core;

namespace DeliveryService.core
{
    public interface IDeliveryDbContext
    {
        public DbSet<Delivery> delivery { get; set; }
        public DbSet<Storehouse> storehouse { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
