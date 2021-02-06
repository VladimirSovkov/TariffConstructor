using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using TariffConstructor.Domain;
using TariffConstructor.Domain.TariffModel.Toolkit;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.TariffModel
{
    public interface ITariffRepository : IRepository<Tariff>
    {
        Task<Dictionary<int, List<int>>> GetAllProductIdsGroupByTariffId( params int[] tariffIds );

        Task<int[]> GetIncludedProductIdsInTariffs( params int[] tariffIds );
        Task<int[]> GetIncludedProductIdsInProductOptionTariffs( params int[] productOptionTariffIds );
        Task<Tariff> GetTariff( int tariffId );
        Task<List<Tariff>> GetTariffs();
        Task<Tariff> GeTariffFirstOrDefaultSettingPreset(int idSettingPreset);
        Task<Tariff> GeTariffFirstOrDefaulTermsOfUse(int idTermsOfUse);
        Task<List<Tariff>> GetTariffs( params int[] tariffIds );
        Task<SearchResult<Tariff>> GetFoundTariff(TarifftSearchPattern searchPattern);
    }
}
