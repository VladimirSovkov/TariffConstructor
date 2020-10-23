using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TariffConstructor.Infrastructure.Data;

namespace TariffConstructor.Infrastructure.Migrations
{
    public class Startup : IStartup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TariffConstructorContext>(x =>
                   x.UseSqlServer("Data Source=DESKTOP-8OP5EQ1\\MSSQLEXPRESS;Initial Catalog=TariffConstructor;Integrated Security=True"));

            return services.BuildServiceProvider();
        }

        public virtual void Configure(IApplicationBuilder app)
        {

        }
    }
}
