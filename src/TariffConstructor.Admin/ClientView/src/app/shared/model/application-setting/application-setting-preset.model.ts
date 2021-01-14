import {SettingsPresetValue} from '../setting/settings-preset-value.model';

export class ApplicationSettingPreset {
  id: number;
  settingsPresetId: number;
  applicationSettingId: number;
  value: SettingsPresetValue = new SettingsPresetValue();
  isRequired: boolean;
  isReadOnly: boolean;
  isHidden: boolean;
}
