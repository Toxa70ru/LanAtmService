using DeliveryService.core;
using DeliveryService.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;


namespace DeliveryService.Infrastructure
{

    public class DeliveryDbContext : DbContext, IDeliveryDbContext
    {
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options)
        : base(options) { }
        public DbSet<Delivery> delivery { get; set; }
        public DbSet<Storehouse> storehouse { get; set; }

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
            builder.ApplyConfiguration(new DeliveryConfiguration());
            builder.ApplyConfiguration(new StorehouseConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
