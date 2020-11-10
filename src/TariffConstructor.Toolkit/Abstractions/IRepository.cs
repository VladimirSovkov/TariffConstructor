using System.Threading.Tasks;

namespace TariffConstructor.Toolkit.Abstractions
{
    public interface IRepository<TAggregate> where TAggregate : Entity, IAggregateRoot
    {
    }
}
