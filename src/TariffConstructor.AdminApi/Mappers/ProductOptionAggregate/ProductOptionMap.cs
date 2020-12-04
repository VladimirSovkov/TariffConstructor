using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.Domain.ProductOptionAggregate;

namespace TariffConstructor.AdminApi.Mappers.ProductOptionAggregate
{
    public static class ProductOptionMap
    {
        public static ProductOptionDto Map(this ProductOption productOption)
        {
            if (productOption == null)
            {
                return null;
            }
            else
            {
                return new ProductOptionDto
                {
                    Id = productOption.Id,
                    Name = productOption.Name,
                    IsMultiple = productOption.IsMultiple,
                    AccountingName = productOption.AccountingName,
                    NomenclatureId = productOption.NomenclatureId,
                    ProductId = productOption.ProductId
                };
            }
        }

        public static IReadOnlyList<ProductOptionDto> Map (this IEnumerable<ProductOption> productOptions)
        {
            return productOptions == null ? new List<ProductOptionDto>() : productOptions.Select(Map).ToList();
        }
    }
}
