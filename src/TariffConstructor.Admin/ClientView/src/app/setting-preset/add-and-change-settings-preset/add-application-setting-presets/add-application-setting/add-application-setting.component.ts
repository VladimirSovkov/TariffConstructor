import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {SnackBarService} from '../../../../shared/service/snack-bar.service';
import {ApplicationSettingApiServices} from '../../../../shared/service/application-setting/application-setting.services';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ApplicationSetting} from '../../../../shared/model/application-setting/application-setting.model';
import {Setting} from '../../../../shared/model/setting/setting.model';
import {Application} from '../../../../shared/model/application/application.model';
import {SettingApiServices} from '../../../../shared/service/setting/setting-api.services';
import {ApplicationApiService} from '../../../../shared/service/application/application-api.service';

@Component({
  selector: 'app-add-application-setting',
  templateUrl: './add-application-setting.component.html',
  styleUrls: ['./add-application-setting.component.css']
})
export class AddApplicationSettingComponent implements OnInit {
  id: number;
  form: FormGroup;
  appSetting: ApplicationSetting;
  settings: Setting[];
  applications: Application[];
  constructor(public dialogRef: MatDialogRef<AddApplicationSettingComponent>,
              private snackBarService: SnackBarService,
              private appSettingService: ApplicationSettingApiServices,
              private settingService: SettingApiServices,
              private applicationService: ApplicationApiService,
              private dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadSettings();
    this.loadApplications();
    this.formInitialization();
  }

  private formInitialization(): void {
    this.form = new FormGroup({
      applicationId: new FormControl( '', [Validators.required]),
      settingId: new FormControl('', [Validators.required]),
      defaultValue: new FormControl('')
    });
  }

  public addAppSetting(): void {
    this.appSetting = this.form.getRawValue();
    this.appSetting.id = this.id;
    console.log('appSetting: ', this.appSetting);
    this.appSettingService.add(this.appSetting)
      .subscribe(() => {
        this.formInitialization();
        this.dialogRef.close();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  private loadSettings(): void{
    this.settingService.getSettings()
      .subscribe((settings: Setting[]) => {
        this.settings = settings;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  private loadApplications(): void {
    this.applicationService.getApplications()
      .subscribe((applications: Application[]) => {
        this.applications = applications;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

}
