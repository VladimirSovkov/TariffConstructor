using System;
using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Domain.ProductModel;
using TariffConstructor.Domain.ProductOptionModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Exceptions;
using TariffConstructor.Domain.ContractKindModel;

namespace TariffConstructor.Domain.TariffModel
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
        public virtual TariffTestPeriod TestPeriod { get; private set; }

        /// <summary>
        /// Бухгалтерское наименование тарифа (обычно используется в бухгалтерских документах)
        /// </summary>
        public string AccountingName { get; private set; }

        /// <summary>
        /// Тип оплаты тарифа
        /// </summary>
        public PaymentType PaymentType { get; private set; }

        /// <summary>
        /// Тип оплаты тарифа
        /// </summary>
        public string AwaitingPaymentStrategy { get; private set; }//пока не надо 

        /// <summary>
        /// Идентификатор тарифа в бухгалтерской системе
        /// </summary>
        public string AccountingTariffId { get; private set; }

        /// <summary>
        /// Идентификатор предустановок для приложений и других сервисов
        /// </summary>
        public int? SettingsPresetId { get; private set; }

        /// <summary>
        /// Условия использования тарифа
        /// </summary>
        public int? TermsOfUseId { get; private set; }

        /// <summary>
        /// Показывает требуется ли акцепт для использования данного тарифа
        /// </summary>
        public bool IsAcceptanceRequired { get; private set; }


        /// <summary>
        /// Показывает доступен ли для плавного завершения
        /// </summary>
        public bool IsGradualFinishAvailable { get; private set; }

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

        public IReadOnlyList<string> CanAddContractKind(ContractKind contractKind)
        {
            List<string> errors = new List<string>();
            if (contractKind == null)
            {
                errors.Add(ValidationMessage.MustSpecify("product option"));
            }
            else
            {
                if (contractKind.Id == 0)
                {
                    errors.Add(ValidationMessage.MustSpecify("product option id"));
                }

                if (ContractKindBindings.FirstOrDefault(x => x.ContractKindId == contractKind.Id) != null)
                {
                    errors.Add(ValidationMessage.AlreadyExists("product option"));
                }
            }

            return errors;
        }

        public void AddAvailableContractKind( ContractKind contractKind )
        {
            if (CanAddContractKind(contractKind).Any())
            {
                throw new InvalidOperationException();
            }

            _contractKindBindings.Add(new TariffToContractKindBinding(contractKind.Id));
        }

        public bool HasTestPeriod()
        {
            return TestPeriod.Value > 0;
        }

        public void SetIsAcceptanceRequired(bool isAcceptanceRequired)
        {
            IsAcceptanceRequired = isAcceptanceRequired;
        }

        public void SetIsGradualFinishAvailable(bool isGradualFinishAvailable)
        {
            IsGradualFinishAvailable = isGradualFinishAvailable;
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

        public void SetArchive(bool isArchived)
        {
            IsArchived = isArchived;
        }

        public void SetAccountingName(string accountingName)
        {
            AccountingName = accountingName;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetPaymentType(PaymentType paymentType)
        {
            PaymentType = paymentType;
        }

        public void RemovePriceItems(List<TariffPrice> prices)
        {
            var count = Prices.Count();
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                var item = Prices.ElementAt(j);
                if (prices.FirstOrDefault(x => x.Period == item.Period && x.Price.Currency == item.Price.Currency) == null)
                    _prices.Remove(item);
                else
                    j++;
            }
        }

        public void RemoveAdvancePrices(List<TariffAdvancePrice> advancePrices)
        {
            var count = AdvancePrices.Count();
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                var item = AdvancePrices.ElementAt(j);
                if (advancePrices.FirstOrDefault(x => x.Period == item.Period && x.Price.Currency == item.Price.Currency) == null)
                    _advancePrices.Remove(item);
                else
                    j++;
            }
        }

        public void RemoveIncludedProduct(List<int> includedProductId)
        {
            var count = IncludedProducts.Count();
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                var item = IncludedProducts.ElementAt(j);
                if (!includedProductId.Contains(item.ProductId))
                    _includedProducts.Remove(item);
                else
                    j++;
            }
        }

        public void RemoveIncludedProductOption(List<int> includedProductOptionId)
        {
            var count = IncludedProductOptions.Count();
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                var item = IncludedProductOptions.ElementAt(j);
                if (!includedProductOptionId.Contains(item.ProductOptionId))
                    _includedProductOptions.Remove(item);
                else
                    j++;
            }
        }

        public void RemoveContractKindBinding(List<int> contractKindBindingId)
        {
            var count = ContractKindBindings.Count();
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                var item = ContractKindBindings.ElementAt(j);
                if (!contractKindBindingId.Contains(item.ContractKindId))
                    _contractKindBindings.Remove(item);
                else
                    j++;
            }
        }

        public IReadOnlyList<string> CanChangePriceItem(Price price, ProlongationPeriod period)
        {
            List<string> errors = new List<string>();
            if (price == null)
            {
                errors.Add(ValidationMessage.MustSpecify("price"));
            }

            if (period == null)
            {
                errors.Add(ValidationMessage.MustSpecify("period"));
            }

            return errors;
        }

        public IReadOnlyList<string> CanChangeAdvancePriceItem(Price price, ProlongationPeriod period)
        {
            List<string> errors = new List<string>();
            if (price == null)
            {
                errors.Add(ValidationMessage.MustSpecify("price"));
            }

            if (period == null)
            {
                errors.Add(ValidationMessage.MustSpecify("period"));
            }

            return errors;
        }



        public void ChangePriceItem(Price price, ProlongationPeriod period)
        {
            if (CanChangePriceItem(price, period).Any())
            {
                throw new InvalidOperationException();
            }

            var index = _prices.FindIndex(x => x.Period == period && x.Price.Currency == price.Currency);
            _prices[index].SetPrice(price);
            _prices[index].SetPeriod(period);
        }

        public void ChangeAdvancePrice(Price price, ProlongationPeriod period)
        {
            if (CanChangeAdvancePriceItem(price, period).Any())
            {
                throw new InvalidOperationException();
            }
            var index = _advancePrices.FindIndex(x => x.Period == period && x.Price.Currency == price.Currency);
            _advancePrices[index].SetPrice(price);
            _advancePrices[index].SetPeriod(period);
        }

        public IReadOnlyList<string> CanChangeProduct(Product product, int relativeWeight = 1)
        {
            List<string> errors = new List<string>();
            if (product == null)
            {
                errors.Add(ValidationMessage.MustSpecify("product"));
            }
            else
            {
                if (product.Id == 0)
                {
                    errors.Add(ValidationMessage.MustSpecify("product id"));
                }
            }

            if (relativeWeight < 0)
            {
                errors.Add(ValidationMessage.Incorrect("relative weight"));
            }

            return errors;
        }

        public void ChangeProduct(IncludedProductInTariff includedProductInTariff, Product product, int relativeWeight = 1)
        {
            if (CanChangeProduct(product, relativeWeight).Any())
            {
                throw new InvalidOperationException();
            }

            var index = _includedProducts.FindIndex(x => x.ProductId == includedProductInTariff.ProductId);
            _includedProducts[index].SetProductId(includedProductInTariff.ProductId);
            _includedProducts[index].SetRelativeWeight(relativeWeight);
        }

        public IReadOnlyList<string> CanChangeProductOption(ProductOption productOption, int quantity = 1)
        {
            List<string> errors = new List<string>();
            if (quantity <= 0)
            {
                errors.Add(ValidationMessage.MustBeGreater("Product option quantity", "0"));
            }
            else if (productOption == null)
            {
                errors.Add(ValidationMessage.MustSpecify("product option"));
            }
            else
            {
                if (productOption.Id == 0)
                {
                    errors.Add(ValidationMessage.MustSpecify("product option id"));
                }
            }

            return errors;
        }
         
        public void ChangeProductOption(IncludedProductOptionInTariff includedProductOption,
            ProductOption productOption, 
            int quantity)
        {
            if (CanChangeProductOption(productOption, quantity).Any())
            {
                throw new InvalidOperationException();
            }
            var index = _includedProductOptions.FindIndex(x => 
                x.ProductOptionId == includedProductOption.ProductOptionId);
            _includedProductOptions[index].SetQuantity(quantity);
            _includedProductOptions[index].SetProductOptionId(productOption.Id);
        }

        public IReadOnlyList<string> CanChangeContractKind(ContractKind contractKind)
        {
            List<string> errors = new List<string>();
            if (contractKind == null)
            {
                errors.Add(ValidationMessage.MustSpecify("product option"));
            }
            else
            {
                if (contractKind.Id == 0)
                {
                    errors.Add(ValidationMessage.MustSpecify("product option id"));
                }
            }

            return errors;
        }

        public void ChangeContractKind(TariffToContractKindBinding ContractKindBinding, ContractKind contractKind)
        {
            if (CanChangeContractKind(contractKind).Any())
            {
                throw new InvalidOperationException();
            }
            var index = _contractKindBindings.FindIndex(x => x.ContractKindId == ContractKindBinding.ContractKindId);
            _contractKindBindings[index].SetContractKindId(contractKind.Id);
        }

        protected Tariff()
        {
        }
    }
}
