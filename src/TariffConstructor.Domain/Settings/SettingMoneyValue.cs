namespace Billing.Services.Ordering.Domain.Subscriptions.Settings
{
    public class MoneyValue
    {
        public decimal Amount { get; }
        public string Curency { get; }

        public MoneyValue( decimal amount, string currency )
        {
            Amount = amount;
            Curency = currency;
        }
    }
}
