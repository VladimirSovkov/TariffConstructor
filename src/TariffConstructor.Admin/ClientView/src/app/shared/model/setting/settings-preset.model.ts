import {BillingsSettingPreset} from '../billing-setting/billings-setting-preset.model';
import {ApplicationSettingPreset} from '../application-setting/application-setting-preset.model';

export class SettingsPreset {
  id: number;
  name: string;
  billingsSettingPresets: BillingsSettingPreset[] = [];
  applicationSettingsPresets: ApplicationSettingPreset[] = [];
}
