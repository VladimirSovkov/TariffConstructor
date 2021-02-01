import {SettingsPresetValue} from '../setting/settings-preset-value.model';
import {BillingSetting} from './billing-setting/billing-setting.model';

export class BillingsSettingPreset {
  id: number;
  settingsPresetId: number;
  billingSettingId: number;
  billingSetting: BillingSetting;
  value: SettingsPresetValue;
  isRequired: boolean;
  isReadOnly: boolean;
  isHidden: boolean;
}
