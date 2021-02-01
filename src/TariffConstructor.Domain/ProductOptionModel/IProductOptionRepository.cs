using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.ProductOptionModel
{
    public interface IProductOptionRepository : IRepository<ProductOption>
    {
        Task<ProductOption> GetProductOption( int productOptionId );
        Task<ProductOption> GetProductOption(string publicId);

        Task<List<ProductOption>> GetProductOptions( int[] productOptionIds );

        Task<List<ProductOption>> GetProductOptions();

        Task<SearchResult<ProductOption>> Search(ProductOptionSearchPattern searchPattern);
    }
}
