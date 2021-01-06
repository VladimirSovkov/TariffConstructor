using System;
using TariffConstructor.Domain.SettingAggregate;
using TariffConstructor.Toolkit.Abstractions;

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

        public void SetSetting(int settingId)
        {
            if (SettingId != settingId)
            {
                SettingId = settingId;
                Setting = null;
            }
        }

        protected BillingSetting()
        {
        }
    }
}
