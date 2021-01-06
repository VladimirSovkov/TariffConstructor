using System.Threading.Tasks;

namespace TariffConstructor.Toolkit.Abstractions
{
    public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
    }
}
