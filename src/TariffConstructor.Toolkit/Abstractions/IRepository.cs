using System.Threading.Tasks;

namespace TariffConstructor.Toolkit.Abstractions
{
    public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}
