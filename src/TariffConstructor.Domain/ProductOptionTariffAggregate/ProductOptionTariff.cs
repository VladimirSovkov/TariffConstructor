using System;
using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.ProductOptionAggregate;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Exceptions;

namespace TariffConstructor.Domain.ProductOptionTariffAggregate
{
    public class ProductOptionTariff : MultitenancyEntity, IAggregateRoot
    {
        public ProductOptionTariff(
            int productOptionId,
            string name,
            string publicId = null )
        {
            ProductOptionId = productOptionId;
            Name = name;
            PublicId = String.IsNullOrEmpty( publicId ) ? Guid.NewGuid().ToString() : publicId;
        }

        public string PublicId { get; private set; }

        public int ProductOptionId { get; private set; }
        public virtual ProductOption ProductOption { get; protected set; }

        public string Name { get; private set; }

        public DateTime CreationDate { get; private set; }

        private readonly List<ProductOptionTariffPrice> _prices = new List<ProductOptionTariffPrice>();

        public virtual IReadOnlyCollection<ProductOptionTariffPrice> Prices => _prices.AsReadOnly();

        public Price GetPrice( ProlongationPeriod prolongationPeriod, string currency )
        {
            return Prices.FirstOrDefault( x => x.Period == prolongationPeriod
                                               && x.Price.Currency == currency )?.Price;
        }

        /// <summary>
        /// Абонентская плата за период
        /// </summary>
        /// <param name="prolongationPeriod"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Price GetFeeForThePeriod( ProlongationPeriod prolongationPeriod, string currency, PaymentType paymentType )
        {
            switch ( paymentType )
            {
                case PaymentType.Prepaid:
                case PaymentType.Postpaid:
                    return GetPrice( prolongationPeriod, currency );
                case PaymentType.Commission:
                    return new Price( 0, currency );
                default:
                    throw new InvalidOperationException();
            }
        }

        public IReadOnlyList<string> CanAddPriceItem( Price price, ProlongationPeriod period )
        {
            List<string> errors = new List<string>();
            if ( price == null )
            {
                errors.Add( ValidationMessage.MustSpecify( "price" ) );
            }
            if ( period == null )
            {
                errors.Add( ValidationMessage.MustSpecify( "period" ) );
            }
            else
            {
                if ( price != null && Prices.FirstOrDefault( x => x.Period == period
                                                                  && x.Price.Currency == price.Currency ) != null )
                {
                    errors.Add( ValidationMessage.AlreadyExists( "price for specified period" ) );
                }
            }

            return errors;
        }

        public void AddPriceItem( Price price, ProlongationPeriod period )
        {
            if ( CanAddPriceItem( price, period ).Any() )
            {
                throw new InvalidOperationException();
            }

            _prices.Add( new ProductOptionTariffPrice( Id, price, period ) );
        }

        protected ProductOptionTariff()
        {
        }
    }
}
