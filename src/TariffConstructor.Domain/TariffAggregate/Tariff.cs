using System;
using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.Domain.ProductOptionAggregate;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Exceptions;

namespace TariffConstructor.Domain.TariffAggregate
{
    public class Tariff : MultitenancyEntity, IAggregateRoot
    {
        public Tariff(
            string name,
            PaymentType paymentType,
            string publicId = null )
        {
            Name = name;
            PaymentType = paymentType;
            TestPeriod = TariffTestPeriod.Empty();
            PublicId = String.IsNullOrEmpty( publicId ) ? Guid.NewGuid().ToString() : publicId;
            AccountingName = name;
        }

        public string PublicId { get; private set; }

        public string Name { get; private set; }

        public DateTime CreationDate { get; private set; } 

        public bool IsArchived { get; private set; }

        /// <summary>
        /// Тестовый период
        /// </summary>
        public virtual TariffTestPeriod TestPeriod { get; private set; } //для добавления нужно будет

        /// <summary>
        /// Бухгалтерское наименование тарифа (обычно используется в бухгалтерских документах)
        /// </summary>
        public string AccountingName { get; private set; }//для добавления нужно будет

        /// <summary>
        /// Тип оплаты тарифа
        /// </summary>
        public PaymentType PaymentType { get; private set; }//для добавления нужно будет

        /// <summary>
        /// Тип оплаты тарифа
        /// </summary>
        public string AwaitingPaymentStrategy { get; private set; }//пока не надо 

        /// <summary>
        /// Идентификатор тарифа в бухгалтерской системе
        /// </summary>
        public string AccountingTariffId { get; private set; }//для добавления нужно будет

        /// <summary>
        /// Идентификатор предустановок для приложений и других сервисов
        /// </summary>
        public int? SettingsPresetId { get; private set; }// выпадающий список. По умолчанию = 0

        /// <summary>
        /// Условия использования тарифа
        /// </summary>
        public int? TermsOfUseId { get; private set; }// выпадающий список. По умолчанию = 0

        /// <summary>
        /// Показывает требуется ли акцепт для использования данного тарифа
        /// </summary>
        public bool IsAcceptanceRequired { get; private set; }//check box


        /// <summary>
        /// Показывает доступен ли для плавного завершения
        /// </summary>
        public bool IsGradualFinishAvailable { get; private set; }//check box

        /// <summary>
        /// Прайс-лист тарифа по периодам
        /// нужно будет для добавления тарифа
        /// </summary>
        private readonly List<TariffPrice> _prices = new List<TariffPrice>();

        public virtual IReadOnlyCollection<TariffPrice> Prices => _prices.AsReadOnly();

        /// <summary>
        /// Прайс-лист суммы аванса по периодам
        /// </summary>
        private readonly List<TariffAdvancePrice> _advancePrices = new List<TariffAdvancePrice>();

        public virtual IReadOnlyCollection<TariffAdvancePrice> AdvancePrices => _advancePrices.AsReadOnly();

        /// <summary>
        /// Список продуктов в тарифе
        /// </summary>
        private readonly List<IncludedProductInTariff> _includedProducts = new List<IncludedProductInTariff>();

        public virtual IReadOnlyCollection<IncludedProductInTariff> IncludedProducts => _includedProducts.AsReadOnly();

        /// <summary>
        /// Список опций продуктов в тарифе
        /// </summary>
        private readonly List<IncludedProductOptionInTariff> _includedProductOptions =
            new List<IncludedProductOptionInTariff>();

        public virtual IReadOnlyCollection<IncludedProductOptionInTariff> IncludedProductOptions =>
            _includedProductOptions.AsReadOnly();

        /// <summary>
        /// Список видов договоров, по которым может быть использован тариф
        /// </summary>
        private readonly List<TariffToContractKindBinding> _contractKindBindings =
            new List<TariffToContractKindBinding>();

        public virtual IReadOnlyCollection<TariffToContractKindBinding> ContractKindBindings =>
            _contractKindBindings.AsReadOnly();

        /// <summary>
        ///     Стоимость тарифа за период
        /// </summary>
        /// <param name="prolongationPeriod"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Price GetPrice( ProlongationPeriod prolongationPeriod, string currency )
        {
            return Prices.FirstOrDefault( x => x.Period == prolongationPeriod
                                               && x.Price.Currency == currency )?.Price;
        }

        /// <summary>
        ///     Сумма аванса по тарифу
        /// </summary>
        public Price GetAdvancePrice( ProlongationPeriod prolongationPeriod, string currency )
        {
            return AdvancePrices.FirstOrDefault( x => x.Period == prolongationPeriod
                                                      && x.Price.Currency == currency )?.Price;
        }

        /// <summary>
        /// Абонентская плата за период
        /// </summary>
        /// <param name="prolongationPeriod"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Price GetFeeForThePeriod(ProlongationPeriod prolongationPeriod, string currency)
        {
            switch (PaymentType)
            {
                case PaymentType.Prepaid:
                case PaymentType.Postpaid:
                    return GetPrice(prolongationPeriod, currency);
                case PaymentType.Commission:
                    return new Price(0, currency);
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

        public IReadOnlyList<string> CanAddAdvancePriceItem( Price price, ProlongationPeriod period )
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
                if ( price != null && AdvancePrices.FirstOrDefault( x => x.Period == period
                                                                         && x.Price.Currency == price.Currency ) !=
                     null )
                {
                    errors.Add( ValidationMessage.AlreadyExists( "prepay price for specified period" ) );
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

            _prices.Add( new TariffPrice( price, period ) );
        }

        public void AddAdvancePriceItem( Price price, ProlongationPeriod period )
        {
            if ( CanAddAdvancePriceItem( price, period ).Any() )
            {
                throw new InvalidOperationException();
            }

            _advancePrices.Add( new TariffAdvancePrice( price, period ) );
        }

        public IReadOnlyList<string> CanAddProduct( Product product, int relativeWeight = 1 )
        {
            List<string> errors = new List<string>();
            if ( product == null )
            {
                errors.Add( ValidationMessage.MustSpecify( "product" ) );
            }
            else
            {
                if ( product.Id == 0 )
                {
                    errors.Add( ValidationMessage.MustSpecify( "product id" ) );
                }
                else if ( IncludedProducts.FirstOrDefault( x => x.ProductId == product.Id ) != null )
                {
                    errors.Add( ValidationMessage.AlreadyExists( "product" ) );
                }
            }

            if ( relativeWeight < 0 )
            {
                errors.Add( ValidationMessage.Incorrect( "relative weight" ) );
            }

            return errors;
        }

        public void AddProduct( Product product, int relativeWeight = 1 )
        {
            if ( CanAddProduct( product, relativeWeight ).Any() )
            {
                throw new InvalidOperationException();
            }

            _includedProducts.Add( new IncludedProductInTariff( product.Id, relativeWeight ) );
        }

        public IReadOnlyList<string> CanAddProductOption( ProductOption productOption, int quantity = 1 )
        {
            List<string> errors = new List<string>();
            if ( quantity <= 0 )
            {
                errors.Add( ValidationMessage.MustBeGreater( "Product option quantity", "0" ) );
            }
            else if ( productOption == null )
            {
                errors.Add( ValidationMessage.MustSpecify( "product option" ) );
            }
            else
            {
                if ( productOption.Id == 0 )
                {
                    errors.Add( ValidationMessage.MustSpecify( "product option id" ) );
                }

                if ( IncludedProductOptions.FirstOrDefault( x => x.ProductOptionId == productOption.Id ) != null )
                {
                    errors.Add( ValidationMessage.AlreadyExists( "product option" ) );
                }
            }

            return errors;
        }

        public void AddProductOption( ProductOption productOption, int quantity = 1 )
        {
            if ( CanAddProductOption( productOption, quantity ).Any() )
            {
                throw new InvalidOperationException();
            }

            _includedProductOptions.Add( new IncludedProductOptionInTariff( productOption.Id, quantity ) );
        }

        public void AddTestPeriod(TariffTestPeriod testPeriod)
        {
            TestPeriod = testPeriod;
        }

        public void AddAvailableContractKind( int contractKindId )
        {
            if ( _contractKindBindings.Any( x => x.ContractKindId == contractKindId ) )
            {
                return;
            }

            _contractKindBindings.Add( new TariffToContractKindBinding( contractKindId ) );
        }

        public bool HasTestPeriod()
        {
            return TestPeriod.Value > 0;
        }

        public bool IsAvailableForUpdate()
        {
            return !IsAcceptanceRequired;
        }

        public void SetAccountingTariffId( string accountingTariffId )
        {
            AccountingTariffId = accountingTariffId;
        }

        public void SetTermsOfUseId( int termsOfUseId )
        {
            TermsOfUseId = termsOfUseId;
        }

        public void SetSettingsPresetId( int settingsPresetId )
        {
            SettingsPresetId = settingsPresetId;
        }

        public void SetAwaitingPaymentStrategy( string awaitingPaymentStrategy )
        {
            AwaitingPaymentStrategy = awaitingPaymentStrategy;
        }

        public void Archive()
        {
            IsArchived = true;
        }

        protected Tariff()
        {
        }
    }
}
