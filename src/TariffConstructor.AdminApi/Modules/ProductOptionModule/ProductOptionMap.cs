using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Modules.ProductModule;
using TariffConstructor.Domain.ProductOptionModel;

namespace TariffConstructor.AdminApi.Modules.ProductOptionModule
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
                    PublicId = productOption.PublicId,
                    Name = productOption.Name,
                    IsMultiple = productOption.IsMultiple,
                    AccountingName = productOption.AccountingName,
                    NomenclatureId = productOption.NomenclatureId,
                    ProductId = productOption.ProductId,
                    ProductName = productOption.Product.Name,
                };
            }
        }

        public static IReadOnlyList<ProductOptionDto> Map (this IEnumerable<ProductOption> productOptions)
        {
            return productOptions == null ? new List<ProductOptionDto>() : productOptions.Select(Map).ToList();
        }
    }
}
