
namespace DeliveryService.Infrastructure
{

    public class DeliveryDbInitializer
    {
        public static void Initializer(DeliveryDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
