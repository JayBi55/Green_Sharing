using GreenSharing.API.Filters;
using GreenSharing.API.Logger;
using GreenSharing.API.Repositories.DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace GreenSharing.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var executable = Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(executable);
            AppDomain.CurrentDomain.SetData("Data", path);

            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<GreenSharingContext>();
            var connectionString = Environment.OSVersion.Platform != PlatformID.Unix
                ? configuration?.GetSection("ConnectionStrings")?["GreenSharingDatabase"]
                : configuration?.GetSection("ConnectionStrings")?["GreenSharingDatabase_unix"];

            services.AddDbContext<GreenSharingContext>(options => options.UseSqlServer(connectionString));
            //services.AddDbContext<GreenSharingContext>(opt => opt.UseInMemoryDatabase("GreenSharing"));

            //Bootsrap Microservices and BAL and DAL
            services.BootStrapRepositories();

            services.AddControllers();
            services.AddSwaggerDocument();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "GreenSharing.API", Version = "v1" });
                c.OperationFilter<SwashbuckleOperationFilter>();
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            //Creer ou Mettre a jour la BD
            ApplyMigration<GreenSharingContext>(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts(); //@TODO: Authentication & Authorization
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GreenSharing.API v1"));

            // Turnings this off for now so we can communicate on the local host for desktop
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            //Authentication & Authorization : Must be before UseEndPoints
            app.UseAuthorization();
            //app.UseAuthentication();

            // TODO: Patch here. Solve CORS issue before sending to alpha/prod. 
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ApplyMigration<DbContextType>(IApplicationBuilder application)
        {
            // Migrate and seed the database during startup. Must be synchronous.
            try
            {
                using (var serviceScope = application.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var dbContext = (DbContext)serviceScope.ServiceProvider.GetRequiredService(typeof(DbContextType));

                    dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // I'm using Serilog here, but use the logging solution of your choice.
                // Logger.Error("Failed to migrate or seed database", ex);
            }
        }
    }
}
