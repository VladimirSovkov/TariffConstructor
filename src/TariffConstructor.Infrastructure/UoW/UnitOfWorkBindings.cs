using Microsoft.Extensions.DependencyInjection;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Infrastructure.UoW
{
    public static class UnitOfWorkBindings
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
