using stall.Application.interfaces;

namespace stall.Persistence
{
    public class DbInitializer
    {
        public static void Initializer(stallDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
