using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;


namespace stall.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(
            this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
