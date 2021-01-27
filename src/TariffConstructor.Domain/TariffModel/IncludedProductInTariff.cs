using TariffConstructor.Toolkit.Exceptions;
using TariffConstructor.Domain.ProductModel;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.TariffModel
{
    public class IncludedProductInTariff : Entity
    {
        public IncludedProductInTariff(
            int productId,
            int relativeWeight = 1 )
        {
            ProductId = productId;
            RelativeWeight = relativeWeight;

            ValidateAndThrowRelativeWeight( relativeWeight );
        }

        public int TariffId { get; set; }
        public virtual Tariff Tariff { get; private set; }
        public int ProductId { get; private set; }
        public virtual Product Product { get; private set; }

        /// <summary>
        /// Относительный "вес" продукта в тарифе. Может принимать целые значения. По умолчанию равен 1.
        /// Пример 1: если два продукта в тарифе имеют вес по 1, то их процентное соотношение будет 50% на 50%
        /// Пример 2: если два продукта в тарифе имеют вес по 100, то их процентное соотношение также будет 50% на 50%
        /// Пример 3: если Продукт "А" имеет вес 2, а продукт "Б" имеет вес 1, то это означает что Продукт "А" "тяжелее" Продукта "Б" в два раза, в процентах 66,66% на 33,33%.
        /// Пример 4: если Продукт "А" имеет вес 3, а продукт "Б" имеет вес 1, то это означает что Продукт "А" "тяжелее" Продукта "Б" в три раза, в процентах 75% на 25%.
        /// </summary>
        public int RelativeWeight { get; private set; }

        public void SetRelativeWeight( int relativeWeight )
        {
            ValidateAndThrowRelativeWeight( relativeWeight );

            RelativeWeight = relativeWeight;
        }

        private void ValidateAndThrowRelativeWeight( int relativeWeight )
        {
            if ( relativeWeight < 0 )
            {
                throw new InvariantViolationException(
                    ValidationMessage.Incorrect( "realtive weight" ),
                    TariffErrorCode.IncorrectRelativeWeightValue );
            }
        }

        public void SetProductId(int productId)
        {
            if (ProductId != productId)
            {
                ProductId = productId;
            }
        }

        protected IncludedProductInTariff()
        {
            RelativeWeight = 1;
        }
    }
}
