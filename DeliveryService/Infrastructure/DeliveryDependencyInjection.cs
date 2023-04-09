using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DeliveryService.core;

namespace DeliveryService.Infrastructure
{
    public static class DeliveryDependencyInjection
    {
        public static IServiceCollection AddPersistense(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectiongString = configuration["DbConnection"];

            services.AddDbContext<DeliveryDbContext>(options =>
            {
                // TODO: исправить ошибку потери соединения
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IDeliveryDbContext>(prov => prov.GetService<DeliveryDbContext>());

            return services;
        }
    }
}
