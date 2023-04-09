using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OrderService.core.Common.Mappings;
using OrderService.core;

namespace OrderService.Infrastructure
{
    public static class OrderDependencyInjection
    {
        public static IServiceCollection AddPersistense(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectiongString = configuration["DbConnection"];

            services.AddDbContext<OrderDbContext>(options =>
            {
                // TODO: исправить ошибку потери соединения
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IOrderDbContext>(prov => prov.GetService<OrderDbContext>());

            return services;
        }
    }
}
