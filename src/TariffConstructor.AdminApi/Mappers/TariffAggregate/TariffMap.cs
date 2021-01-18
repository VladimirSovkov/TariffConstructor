using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.AdminApi.Dto.TariffAggragate;
using TariffConstructor.Domain.TariffModel;

namespace TariffConstructor.AdminApi.Mappers.TariffAggregate
{
    public static class TariffMap
    {
        public static SimplifiedTariffDto ToSimplifiedTariffDto(this Tariff tariff)
        {
            if (tariff == null)
            {
                return null;
            }
            else
            {
                return new SimplifiedTariffDto
                {
                    Id = tariff.Id,
                    TenantId = tariff.TenantId,
                    Name = tariff.Name,
                    PaymentType = (int)tariff.PaymentType,
                    ContractKindBindings = tariff.ContractKindBindings.ToList()
                };
            }
        }

        public static IReadOnlyList<SimplifiedTariffDto> ToSimplifiedTariffDtos(this IEnumerable<Tariff> tariffs)
        {
            return tariffs == null ? new List<SimplifiedTariffDto>() : tariffs.Select(ToSimplifiedTariffDto).ToList();
        }

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
                    ValueTestPeriod = tariff.TestPeriod.Value,
                    UnitTestPeriod = (int)tariff.TestPeriod.Unit,
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
