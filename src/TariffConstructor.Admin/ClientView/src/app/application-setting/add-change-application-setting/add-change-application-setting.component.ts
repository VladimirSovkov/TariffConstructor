import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {ApplicationSettingApiServices} from '../../shared/service/application-setting/application-setting.services';
import {ApplicationSetting} from '../../shared/model/application-setting/application-setting.model';
import {of} from 'rxjs';
import {SettingApiServices} from '../../shared/service/setting/setting-api.services';
import {Setting} from '../../shared/model/setting/setting.model';

@Component({
  selector: 'app-add-change-application-setting',
  templateUrl: './add-change-application-setting.component.html',
  styleUrls: ['./add-change-application-setting.component.css']
})
export class AddChangeApplicationSettingComponent implements OnInit {
  isChangeApplicationSetting = false;
  id: number;
  form: FormGroup;
  appSetting: ApplicationSetting;
  settings: Setting[];
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private appSettingService: ApplicationSettingApiServices,
              private settingService: SettingApiServices) { }

  ngOnInit(): void {
    this.loadSetting();
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.load(this.id);
        this.isChangeApplicationSetting = true;
      }
    });
    this.formInitialization();
  }

  private load(id: number): void {
    this.appSettingService.get(id)
      .subscribe((appSetting: ApplicationSetting) => {
        this.appSetting = appSetting;
        this.form.patchValue(appSetting);
        console.log('appSetting: ', appSetting);
      });
  }

  private formInitialization(): void {
    this.form = new FormGroup({
      applicationId: new FormControl(0, [Validators.required]),
      settingId: new FormControl(0, [Validators.required]),
      defaultValue: new FormControl('')
    });
  }

  action(): void {
    this.appSetting = this.form.getRawValue();
    this.appSetting.id = this.id;
    console.log('appSetting: ', this.appSetting);
    if (this.isChangeApplicationSetting){
      this.updateAppSetting(this.appSetting);
    }
    else {
      this.addAppsetting(this.appSetting);
    }
  }

  private updateAppSetting(appSetting: ApplicationSetting): void {
    this.appSettingService.update(appSetting)
      .subscribe( () => {
        this.formInitialization();
        this.router.navigate(['applicationSetting']);
      });
  }

  private addAppsetting(appSetting: ApplicationSetting): void {
    this.appSettingService.add(appSetting)
      .subscribe(() => {
        this.formInitialization();
        console.log('Добавил');
      });
  }

  private loadSetting(): void{
    this.settingService.getSettings()
      .subscribe((settings: Setting[]) => {
        this.settings = settings;
      });
  }
}
