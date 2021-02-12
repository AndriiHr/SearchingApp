using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SearchingApp.Application.Commands;
using SearchingApp.Infrastructure.DbContexts;
using SearchingApp.Infrastructure.Interceptor;


namespace SeachingApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();           
            services.AddMediatR(typeof(CreateUserRequest).GetTypeInfo().Assembly);
            services.AddScoped<DomainEventDispatcher>();
            services.AddDbContext<EFContext>((serviceProvider, options) =>
            {
                options
                    .AddInterceptors(serviceProvider.GetService<DomainEventDispatcher>())
                    .UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"),
                        builder => builder.MigrationsAssembly("SearchingApp.Infrastructure"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SeachingApp.Api", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SeachingApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}