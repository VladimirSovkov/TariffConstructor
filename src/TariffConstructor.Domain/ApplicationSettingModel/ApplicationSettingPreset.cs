using TariffConstructor.Domain.SettingModel;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ApplicationSettingModel
{
    /// <summary>
    ///     Сущность, определяющая значение по-умолчанию для приложения и допустимые границы его изменения
    /// </summary>
    public class ApplicationSettingPreset : Entity, ISettingPreset
    {
        public ApplicationSettingPreset( 
            int settingsPresetId,
            int applicationSettingId, 
            SettingPresetValue value,
            bool isRequired,
            bool isReadOnly,
            bool isHidden )
        {
            SettingsPresetId = settingsPresetId;
            ApplicationSettingId = applicationSettingId;
            Value = value;
            IsRequired = isRequired;
            IsReadOnly = isReadOnly;
            IsHidden = isHidden;
        }

        public int SettingsPresetId { get; private set; }

        public int ApplicationSettingId { get; private set; }
        public virtual ApplicationSetting ApplicationSetting { get; protected set; }

        public string GetSettingPresetType()
        {
            return nameof( ApplicationSettingPreset );
        }

        public int PresetId => Id;
        public int SettingId => ApplicationSettingId;
        public string SettingPublicId => ApplicationSetting.PublicId;
        public Setting Setting => ApplicationSetting.Setting;
        public virtual SettingPresetValue Value { get; private set; }
        public bool IsRequired { get; private set; }
        public bool IsReadOnly { get; private set; }
        public bool IsHidden { get; private set; }

        protected ApplicationSettingPreset()
        {
        }
    }
}
