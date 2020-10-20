using System;
using TariffConstructor.Domain.Abstractions;
using TariffConstructor.Toolkit.Aggregate;
using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;

namespace TariffConstructor.Domain.BillingSettingAggregate
{
    /// <summary>
    ///     Агрегат, связывающий абстракную настройку с настройкой биллинга
    /// </summary>
    public class BillingSetting : Entity, IAggregateRoot
    {
        public BillingSetting( int settingId, string publicId = null )
        {
            SettingId = settingId;
            PublicId = String.IsNullOrEmpty( publicId ) ? Guid.NewGuid().ToString() : publicId;
        }

        public int SettingId { get; private set; }

        public string PublicId { get; private set; }

        public virtual Setting Setting { get; protected set; }

        protected BillingSetting()
        {
        }
    }
}
