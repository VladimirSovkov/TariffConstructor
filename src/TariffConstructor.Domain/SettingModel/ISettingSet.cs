namespace TariffConstructor.Domain.SettingModel
{
    public interface ISettingSet
    {
        string SettingPublicId { get; }
        Setting Setting { get; }
        string Value { get; }
    }
}
