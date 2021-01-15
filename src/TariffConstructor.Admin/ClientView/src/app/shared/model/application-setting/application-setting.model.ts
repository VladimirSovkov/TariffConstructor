import {Setting} from '../setting/setting.model';
import {Application} from '../application/application.model';

export class ApplicationSetting {
  id: number;
  applicationId: number;
  settingId: number;
  defaultValue: string;
  setting: Setting;
  application: Application;
}
