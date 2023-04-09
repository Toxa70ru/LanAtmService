using Microsoft.EntityFrameworkCore;
using stall.Domain.authorization;
using stall.Domain.courier;
using stall.Domain.customer;
using stall.Domain.seller;
using System.Threading.Tasks;
using System.Threading;
using stall.Persistence.EntityTypeConfigurations.seller;
using stall.Persistence.EntityTypeConfigurations.customer;
using stall.Persistence.EntityTypeConfigurations.courier;
using stall.Persistence.EntityTypeConfigurations.authorization;
using System.Reflection.Emit;

namespace stall.Application.interfaces;

public class stallDbContext : DbContext, IstallDbContext
{
    public stallDbContext(DbContextOptions<stallDbContext> options)
        : base(options) { }
    public DbSet<Category> category { get; set; }
    public DbSet<Manufacturer> manufacturer { get; set; }
    public DbSet<Product> product { get; set; }
    public DbSet<Storehouse> storehouse { get; set; }
    public DbSet<Customer_Table> customer_Table { get; set; }
    public DbSet<Order> order { get; set; }
    public DbSet<Order_Picking> order_Picking { get; set; }
    public DbSet<Status> status { get; set; }
    public DbSet<Courier_Table> courier_Table { get; set; }
    public DbSet<Delivery> delivery { get; set; }
    public DbSet<Reg_User> reg_User { get; set; }
    public DbSet<Role> role { get; set; }

    
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
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new ManufacturerConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new StorehouseConfiguration());

        
        builder.ApplyConfiguration(new Customer_TableConfiguration());
        builder.ApplyConfiguration(new Order_PickingConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new StatusConfiguration());

        
        builder.ApplyConfiguration(new Courier_TableConfiguration());
        builder.ApplyConfiguration(new DeliveryConfiguration());

        
        builder.ApplyConfiguration(new Reg_UserConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());

        base.OnModelCreating(builder);
    }
}
