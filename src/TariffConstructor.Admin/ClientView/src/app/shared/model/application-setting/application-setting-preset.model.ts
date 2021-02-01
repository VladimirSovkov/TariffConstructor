import {SettingsPresetValue} from '../setting/settings-preset-value.model';
import {ApplicationSetting} from './application-setting.model';

export class ApplicationSettingPreset {
  id: number;
  settingsPresetId: number;
  applicationSettingId: number;
  applicationSetting: ApplicationSetting;
  value: SettingsPresetValue = new SettingsPresetValue();
  isRequired: boolean;
  isReadOnly: boolean;
  isHidden: boolean;
}
