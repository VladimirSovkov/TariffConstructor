namespace TariffConstructor.Toolkit.Abstractions
{
    public interface IRepository<TAggregate> where TAggregate : Entity, IAggregateRoot
    {
    }
}
