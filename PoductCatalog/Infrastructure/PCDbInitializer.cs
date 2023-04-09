namespace ProductCatalog.Infrastructure
{
    public class PCDbInitializer
    {
        public static void Initializer(PCDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
