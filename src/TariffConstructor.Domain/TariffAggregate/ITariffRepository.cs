using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using TariffConstructor.Domain.ContractModel;
using TariffConstructor.Domain.TariffAggregate.Toolkit;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.TariffAggregate
{
    public interface ITariffRepository : IRepository<Tariff>
    {
        Task<Dictionary<int, List<int>>> GetAllProductIdsGroupByTariffId( params int[] tariffIds );

        Task<int[]> GetIncludedProductIdsInTariffs( params int[] tariffIds );

        Task<int[]> GetIncludedProductIdsInProductOptionTariffs( params int[] productOptionTariffIds );

        Task<Tariff> GetTariff( int tariffId );

        Task<List<Tariff>> GetTariffs( params int[] tariffIds );

        Task<TariffPaginator> GetTariffs(int countElementInPage, int page = 1);

        Task<SearchResult<Tariff>> GetFoundRates(ContractSearchPattern searchPattern);

        Task<List<Tariff>> GetTariffsWithAcceptanceRequired();
    }
}
