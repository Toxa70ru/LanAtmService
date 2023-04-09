using ProductCatalog.Interfaces.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.core
{
    public interface IPCDbContext
    {
        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Manufacturer> manufacturer { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
