using DeliveryService;
using DeliveryService.Infrastructure;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();


        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<DeliveryDbContext>();
                DeliveryDbInitializer.Initializer(context);
            }
            catch (Exception exeption)
            {

            }
        }

        host.Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                //webBuilder.UseHttpSys();

            });

}