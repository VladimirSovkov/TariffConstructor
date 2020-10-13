using Microsoft.Extensions.DependencyInjection;

namespace TariffConstructor.Infrastructure.Startup
{
    public static class BaseBindings
    {
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
