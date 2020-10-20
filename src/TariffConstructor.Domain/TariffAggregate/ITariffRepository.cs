using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.Abstractions;

namespace TariffConstructor.Domain.TariffAggregate
{
    public interface ITariffRepository : IRepository<Tariff>
    {
        Task<Dictionary<int, List<int>>> GetAllProductIdsGroupByTariffId( params int[] tariffIds );

        Task<int[]> GetIncludedProductIdsInTariffs( params int[] tariffIds );

        Task<int[]> GetIncludedProductIdsInProductOptionTariffs( params int[] productOptionTariffIds );

        Task<Tariff> GetTariff( int tariffId );

        Task<List<Tariff>> GetTariffs( params int[] tariffIds );

        Task<List<Tariff>> GetTariffsWithAcceptanceRequired();
    }
}
