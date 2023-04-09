using Microsoft.EntityFrameworkCore;
using ProductCatalog.Interfaces.Models;
using ProductCatalog.core;
using ProductCatalog.Infrastructure.EntityTypeConfigurations;
using ProductCatalog.Interfaces.Models;


namespace ProductCatalog.Infrastructure
{
    public class PCDbContext : DbContext,IPCDbContext
    {
        public PCDbContext(DbContextOptions<PCDbContext> options)
        : base(options) { }
        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Manufacturer> manufacturer { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }
        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ManufacturerConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
