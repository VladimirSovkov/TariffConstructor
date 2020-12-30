using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TariffConstructor.Infrastructure.Startup;
using TariffConstructor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft;

namespace TariffConstructor.AdminApi
{
    public class Startup : IBaseStartup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }
        public Startup( IConfiguration configuration, IWebHostEnvironment env )
        {
            _env = env;
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvcWithDefaultRoute();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            AddServices(services);
            return services.BuildServiceProvider();
        }

        public void AddServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            services.AddControllers().AddNewtonsoftJson();
            services
                .AddBaseServices()
                .AddMvcCore(options => options.EnableEndpointRouting = false)
                .AddApplicationPart(Assembly.Load(new AssemblyName("TariffConstructor.AdminApi")))
                .AddCors();
            services.AddDbContext<TariffConstructorContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDatabase<TariffConstructorContext>(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
