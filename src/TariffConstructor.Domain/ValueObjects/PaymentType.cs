namespace TariffConstructor.Domain.ValueObjects
{
    public enum PaymentType
    {
        /// <summary>
        /// Абонентская предоплатная модель оплаты
        /// </summary>
        Prepaid = 0,

        /// <summary>
        /// Абонентская постоплатная модель оплаты
        /// </summary>
        Postpaid = 1,

        /// <summary>
        /// Оплата по комиссионному вознаграждению (постоплатные начисления)
        /// </summary>
        Commission = 2
    }
}
