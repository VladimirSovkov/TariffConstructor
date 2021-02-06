using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.AdminApi.Modules.TariffModule.Dto;
using TariffConstructor.AdminApi.Modules.TariffModule.Mappers;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Mappers.TariffMap
{
    public static class TariffMap
    {
        public static TariffDto Map(this Tariff tariff)
        {
            if (tariff == null)
            {
                return null;
            }
            else
            {
                return new TariffDto
                {
                    Id = tariff.Id,
                    Name = tariff.Name,
                    IsArchived = tariff.IsArchived,
                    TestPeriod = tariff.TestPeriod.Map(),
                    AccountingName = tariff.AccountingName,
                    PaymentType = (int)tariff.PaymentType,
                    AwaitingPaymentStrategy = tariff.AwaitingPaymentStrategy,
                    AccountingTariffId = tariff.AccountingName,
                    SettingsPresetId = (int)tariff.SettingsPresetId,
                    TermsOfUseId = (int)tariff.TermsOfUseId,
                    IsAcceptanceRequired = tariff.IsAcceptanceRequired,
                    IsGradualFinishAvailable = tariff.IsGradualFinishAvailable,
                    Prices = (List<TariffPriceDto>)tariff.Prices.Map(),
                    AdvancePrices = (List<TariffAdvancePriceDto>)tariff.AdvancePrices.Map(),
                    IncludedProducts = (List<IncludedProductInTariffDto>)tariff.IncludedProducts.Map(),
                    IncludedProductOptions = (List<IncludedProductOptionInTariffDto>)tariff.IncludedProductOptions.Map(),
                    ContractKindBindings = (List<TariffToContractKindBindingDto>)tariff.ContractKindBindings.Map()
                };
            }
        }

        public static IReadOnlyList<TariffDto> Map (this IEnumerable<Tariff> tariffs)
        {
            return tariffs == null ? new List<TariffDto>() : tariffs.Select(Map).ToList();
        }
    }
}
