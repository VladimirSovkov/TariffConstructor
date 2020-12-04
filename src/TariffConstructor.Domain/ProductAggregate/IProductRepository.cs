using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProduct( int productId );
        Task<List<Product>> GetProducts( IEnumerable<int> productIds );
        Task<List<Product>> GetProducts();
        Task<SearchResult<Product>> Search(ProductSearchPattern searchPattern);
    }
}
