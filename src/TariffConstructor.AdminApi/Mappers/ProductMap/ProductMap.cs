using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.ProductDtoModel;
using TariffConstructor.Domain.ProductModel;

namespace TariffConstructor.AdminApi.Mappers.ProductMap
{
    public static class ProductMap
    {
        public static ProductDto Map(this Product product)
        {
            if (product == null)
            {
                return null;
            }
            else
            {
                return new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    ShortName = product.ShortName,
                    NomenclatureId = product.NomenclatureId
                };
            }
        }

        public static IReadOnlyList<ProductDto> Map(this IEnumerable<Product> products)
        {
            return products == null ? new List<ProductDto>() : products.Select(Map).ToList();
        }
    }
}
