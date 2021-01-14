import {SettingsPresetValue} from '../setting/settings-preset-value.model';

export class BillingsSettingPreset {
  id: number;
  settingsPresetId: number;
  billingSettingId: number;
  value: SettingsPresetValue;
  isRequired: boolean;
  isReadOnly: boolean;
  isHidden: boolean;
}
