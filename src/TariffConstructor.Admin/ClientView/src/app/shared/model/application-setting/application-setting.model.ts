import {Setting} from '../setting/setting.model';

export class ApplicationSetting {
  id: number;
  applicationId: number;
  settingId: number;
  defaultValue: string;
  setting: Setting;
}
