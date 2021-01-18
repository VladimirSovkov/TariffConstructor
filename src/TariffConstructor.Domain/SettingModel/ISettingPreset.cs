namespace TariffConstructor.Domain.SettingModel
{
    public interface ISettingPreset
    {
        string GetSettingPresetType();
        int PresetId { get; }
        int SettingId { get; }
        string SettingPublicId { get; }
        Setting Setting { get; }
        SettingPresetValue Value { get; }
        bool IsRequired { get; }
        bool IsReadOnly { get; }
        bool IsHidden { get; }
    }
}
