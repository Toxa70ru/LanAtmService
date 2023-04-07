using Microsoft.EntityFrameworkCore;
using stall.Domain.authorization;
using stall.Domain.courier;
using stall.Domain.customer;
using stall.Domain.seller;
using System.Threading.Tasks;
using System.Threading;


namespace stall.Application.interfaces;

public interface IstallDbContext 
{
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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
   
}
