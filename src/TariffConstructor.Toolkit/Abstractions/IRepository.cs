using System.Threading.Tasks;

namespace TariffConstructor.Toolkit.Abstractions
{
    public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        Task<TEntity> AddTariff(TEntity entity); //name: Add
        //update
        //delete
        //add
    }
}
