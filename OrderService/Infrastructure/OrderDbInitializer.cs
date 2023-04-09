using OrderService.core.Common.Mappings;

namespace OrderService.Infrastructure
{

    public class OrderDbInitializer
    {
        public static void Initializer(OrderDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
