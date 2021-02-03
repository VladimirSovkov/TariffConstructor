using Microsoft.Extensions.DependencyInjection;
using TariffConstructor.Infrastructure.Data;
using TariffConstructor.Infrastructure.UoW;

namespace TariffConstructor.Infrastructure.Startup
{
    public static class BaseBindings
    {
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            return services.AddRepositories()
                .AddUnitOfWork();
        }
    }
}
