using System.Threading;
using System.Threading.Tasks;
using TariffConstructor.Infrastructure.Data;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TariffConstructorContext _ctx;

        public UnitOfWork(TariffConstructorContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public async Task<bool> SaveEntitiesAsync(string traceId = null, CancellationToken cancellationToken = default)
        {
            return await _ctx.SaveEntitiesAsync(traceId, cancellationToken);
        }
    }
}
