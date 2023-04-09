using Microsoft.EntityFrameworkCore;
using OrderService.core;
using OrderService.Interfaces.models;

namespace OrderService.Infrastructure
{

    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options) { }
        public DbSet<Order> order { get; set; }
        public DbSet<Status> status { get; set; }

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
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new StatusConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
