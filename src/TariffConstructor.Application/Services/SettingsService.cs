//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TariffConstructor.Domain.ApplicationSettingAggregate;
//using TariffConstructor.Domain.BillingSettingAggregate;
//using TariffConstructor.Domain.SettingAggregate;
//using TariffConstructor.Domain.Settings;
//using TariffConstructor.Toolkit.Abstractions;

//namespace TariffConstructor.Application.Services
//{
//    public class SettingsService : ISettingsService
//    {
//        private readonly IRepository<SettingsPreset> _settingsPresetRepository;
//        private readonly IRepository<SettingsSet> _settingsSetRepository;
//        private readonly IRepository<BillingSetting> _billingSettingRepository;
//        private readonly IRepository<ApplicationSetting> _applicationSettingRepository;

//        public SettingsService(
//            IRepository<SettingsPreset> settingsPresetRepository,
//            IRepository<SettingsSet> settingsSetRepository,
//            IRepository<BillingSetting> billingSettingRepository,
//            IRepository<ApplicationSetting> applicationSettingRepository)
//        {
//            _settingsPresetRepository = settingsPresetRepository;
//            _settingsSetRepository = settingsSetRepository;
//            _billingSettingRepository = billingSettingRepository;
//            _applicationSettingRepository = applicationSettingRepository;
//        }

//        public async Task<SettingsSet> CreateSettingsSet(int settingsPresetId, SettingsContainer settings = null)
//        {
//            SettingsPreset settingsPreset =
//                (await _settingsPresetRepository.GetSingleBySpec(new GetSettingsPresetById(settingsPresetId)))
//                .ThrowIfObjectNotFound(settingsPresetId);

//            List<SettingRedefinition> redefinitions = await GetSettingRedefinitions(settings);

//            SettingsSet settingsSet = settingsPreset.Make(redefinitions?.ToArray());

//            _settingsSetRepository.Add(settingsSet);

//            return settingsSet;
//        }

//        private async Task<List<SettingRedefinition>> GetSettingRedefinitions(SettingsContainer settings)
//        {
//            if (settings == null)
//            {
//                return null;
//            }

//            ITypelessSetting[] typelessSettings = GetTypelessSettings(settings).SelectMany(x => x).ToArray();

//            if (!typelessSettings.Any())
//            {
//                return null;
//            }

//            string[] settingPublicIds = typelessSettings.Select(x => x.SettingId).ToArray();

//            var settingsDictionary = new Dictionary<string, Setting>();

//            List<BillingSetting> billingSettings = await _billingSettingRepository.List(
//                new GetBillingSettingsByPublicIds(settingPublicIds.ToArray()));

//            settingsDictionary.AddRange(billingSettings.ToDictionary(x => x.PublicId, x => x.Setting));

//            List<ApplicationSetting> applicationSettings = await _applicationSettingRepository.List(
//                new GetApplicationSettingsByPublicIds(settingPublicIds.ToArray()));

//            settingsDictionary.AddRange(applicationSettings.ToDictionary(x => x.PublicId, x => x.Setting));

//            List<SettingRedefinition> settingRedefinitions = new List<SettingRedefinition>();

//            foreach (ITypelessSetting typelessSetting in typelessSettings)
//            {
//                settingRedefinitions.Add(GetSettingRedefinition(settingsDictionary, typelessSetting));
//            }

//            return settingRedefinitions;
//        }
//        private IEnumerable<IEnumerable<ITypelessSetting>> GetTypelessSettings(SettingsContainer settings)
//        {
//            yield return settings.BooleanSettings ?? new ITypelessSetting[0];
//            yield return settings.IntegerSettings ?? new ITypelessSetting[0];
//            yield return settings.StringSettings ?? new ITypelessSetting[0];
//            yield return settings.EnumSettings ?? new ITypelessSetting[0];
//            yield return settings.MultiEnumSettings ?? new ITypelessSetting[0];
//            yield return settings.MoneySettings ?? new ITypelessSetting[0];
//        }

//        private SettingRedefinition GetSettingRedefinition(
//            Dictionary<string, Setting> settingsDictionary,
//            ITypelessSetting typelessSetting)
//        {
//            Setting setting = settingsDictionary[typelessSetting.SettingId];

//            SettingImplement settingImplement = new SettingImplement(setting);
//            settingImplement.Parse(typelessSetting.TypelessValue);

//            return new SettingRedefinition(typelessSetting.SettingId, settingImplement.RawValue);
//        }
//    }
//}
