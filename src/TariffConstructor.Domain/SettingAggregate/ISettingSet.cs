namespace TariffConstructor.Domain.SettingAggregate
{
    public interface ISettingSet
    {
        string SettingPublicId { get; }
        Setting Setting { get; }
        string Value { get; }
    }
}
