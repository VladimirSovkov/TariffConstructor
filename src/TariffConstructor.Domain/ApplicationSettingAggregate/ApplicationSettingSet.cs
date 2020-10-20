using TariffConstructor.Domain.SettingAggregate;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ApplicationSettingAggregate
{
    /// <summary>
    ///     Зафиксированная настройка приложения
    /// </summary>
    public class ApplicationSettingSet : Entity, ISettingSet
    {
        public ApplicationSettingSet(
            int applicationSettingId,  
            string value )
        {
            ApplicationSettingId = applicationSettingId;
            Value = value;
        }

        public int ApplicationSettingId { get; private set; }
        public virtual ApplicationSetting ApplicationSetting { get; private set; }

        public int SettingsSetId { get; private set; }

        public string SettingPublicId => ApplicationSetting.PublicId;
        public Setting Setting => ApplicationSetting.Setting;
        public string Value { get; private set; }

        protected ApplicationSettingSet()
        {
        }
    }
}
