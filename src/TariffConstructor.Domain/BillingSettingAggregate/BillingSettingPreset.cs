using TariffConstructor.Domain.SettingAggregate;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.BillingSettingAggregate
{
    /// <summary>
    ///     Сущность, определяющая значение по-умолчанию для биллинга и допустимые границы его изменения
    /// </summary>
    public class BillingSettingPreset : Entity, ISettingPreset
    {
        public BillingSettingPreset( 
            int settingsPresetId,
            int billingSettingId, 
            SettingPresetValue value,
            bool isRequired,
            bool isReadOnly,
            bool isHidden )
        {
            SettingsPresetId = settingsPresetId;
            BillingSettingId = billingSettingId;
            Value = value;
            IsRequired = isRequired;
            IsReadOnly = isReadOnly;
            IsHidden = isHidden;
        }

        public int SettingsPresetId { get; private set; }

        public int BillingSettingId { get; private set; }
        public virtual BillingSetting BillingSetting { get; protected set; }

        public string GetSettingPresetType()
        {
            return nameof( BillingSettingPreset );
        }

        public int PresetId => Id;
        public int SettingId => BillingSettingId;
        public string SettingPublicId => BillingSetting.PublicId;
        public Setting Setting => BillingSetting.Setting;
        public virtual SettingPresetValue Value { get; private set; }

        public bool IsRequired { get; private set; }

        public bool IsReadOnly { get; private set; }

        public bool IsHidden { get; private set; }

        protected BillingSettingPreset()
        {
        }
    }
}
