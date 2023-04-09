using OrderService.Interfaces;
using OrderService.Infrastructure;
using OrderService.core.Common.Mappings;
using System.Reflection;
using OrderService.core;
using OrderService.core;
using OrderService.core.Common.Mappings;

namespace OrderService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IOrderDbContext).Assembly));
            });
            services.AddAplication();
            services.AddControllers();
            services.AddPersistense(Configuration);
            services.AddHealthChecks();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll", policy =>
                {

                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddSwaggerGen();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();



            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Цымбал А.В.");
            });
        }
        
    }
}
