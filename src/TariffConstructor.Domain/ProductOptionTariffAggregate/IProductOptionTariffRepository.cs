using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.Abstractions;

namespace TariffConstructor.Domain.ProductOptionTariffAggregate
{
    public interface IProductOptionTariffRepository : IRepository<ProductOptionTariff>
    {
        Task<List<ProductOptionTariff>> GetProductOptionTariffsByIds( int[] productOptionTariffsIds );
    }
}
