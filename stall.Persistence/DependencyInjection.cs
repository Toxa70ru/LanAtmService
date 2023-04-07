using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stall.Application.interfaces;
using Microsoft.EntityFrameworkCore;

namespace stall.Persistence
{
    public static class DependencyInjection 
    {

        public static IServiceCollection AddPersistense(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectiongString = configuration["DbConnection"];

            services.AddDbContext<stallDbContext>(options =>
            {
                // TODO: исправить ошибку потери соединения
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IstallDbContext>(prov => prov.GetService<stallDbContext>()); 
            
            return services;
        }
    }
}
