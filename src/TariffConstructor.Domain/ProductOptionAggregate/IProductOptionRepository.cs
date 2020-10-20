using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ProductOptionAggregate
{
    public interface IProductOptionRepository : IRepository<ProductOption>
    {
        Task<ProductOption> GetProductOption( int productOptionId );

        Task<List<ProductOption>> GetProductOptions( int[] productOptionIds );
    }
}
