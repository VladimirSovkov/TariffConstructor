using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.ProductModel;

namespace TariffConstructor.AdminApi.Modules.ProductModule
{
    public static class ProductMap
    {
        public static ProductDto Map(this Product product)
        {
            if (product == null)
            {
                return null;
            }

                return new ProductDto
                {
                    Id = product.Id,
                    PublicId = product.PublicId,
                    Name = product.Name,
                    ShortName = product.ShortName,
                    NomenclatureId = product.NomenclatureId
                };

        }

        public static IReadOnlyList<ProductDto> Map(this IEnumerable<Product> products)
        {
            return products == null ? new List<ProductDto>() : products.Select(Map).ToList();
        }
    }
}
