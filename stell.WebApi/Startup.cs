using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using stall.Application.Common.Mappings;
using System.Reflection;
using stall.Application.interfaces;
using stall.Application;
using stall.Persistence;
using Microsoft.Extensions.Configuration;
using stall.WebApi.Controllers;
using MediatR;

namespace stall.WebApi
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
                config.AddProfile(new AssemblyMappingProfile(typeof(IstallDbContext).Assembly));
            });
            services.AddAplication();
            services.AddPersistense(Configuration);
            services.AddControllers();
            //services.AddMediatR(typeof(Startup).Assembly);
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
            app.UseSwaggerUI(c => {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Цымбал А.В.");
            });
        }
    }
}
