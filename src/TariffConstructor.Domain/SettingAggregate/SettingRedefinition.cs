namespace TariffConstructor.Domain.SettingAggregate
{
    public class SettingRedefinition
    {
        public SettingRedefinition( string settingPublicId, string newValue )
        {
            SettingPublicId = settingPublicId;
            NewValue = newValue;
        }

        public string SettingPublicId { get; private set; }
        public string NewValue { get; private set; }
    }
}
