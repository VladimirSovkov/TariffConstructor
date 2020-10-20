using TariffConstructor.Toolkit.Aggregate;

namespace TariffConstructor.Domain.Abstractions
{
    public interface IRepository<TAggregate> where TAggregate : Entity, IAggregateRoot
    {
    }
}
