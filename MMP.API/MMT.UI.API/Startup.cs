using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MMT.Infra.CrossCutting.Bus;
using MMT.Infra.CrossCutting.IoC;
using MMT.Infra.Data.Context;
using Serilog;
using Serilog.Events;
using System.IO;

namespace MMT.UI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddCors();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton(Configuration);            

            //Calling Serilog functionality
            CreateLogger();

            // .NET Native DI Abstraction
            RegisterServices(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor accessor, MMTContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            context.Database.Migrate();

            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
        }

        /// <summary>
        /// Register services for Dependency Injectiion
        /// </summary>   
        /// <param name="services"></param>
        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            SimpleInjectorBootStrapper.RegisterServices(services);
        }

        /// <summary>
        /// Configure Serilog
        /// </summary>
        private void CreateLogger()
        {
            string filePath = Configuration["AppSettings:LogFilePath"];
            string fileName = Configuration["AppSettings:LogFileName"];

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.RollingFile(Path.Combine(filePath, fileName), LogEventLevel.Information)
            .CreateLogger();

            Log.Information("MMT.Site - Started.");
        }
    }
}
