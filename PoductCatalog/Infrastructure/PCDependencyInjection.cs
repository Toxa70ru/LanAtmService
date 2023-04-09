using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProductCatalog.core;

namespace ProductCatalog.Infrastructure
{
    public static class PCDependencyInjection
    {
        public static IServiceCollection AddPersistense(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectiongString = configuration["DbConnection"];

            services.AddDbContext<PCDbContext>(options =>
            {
                // TODO: исправить ошибку потери соединения
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IPCDbContext>(prov => prov.GetService<PCDbContext>());

            return services;
        }
    }
}
