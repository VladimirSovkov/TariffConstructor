import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Params, Router, RouterEvent, NavigationEnd, RoutesRecognized} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {ApplicationSettingApiServices} from '../../shared/service/application-setting/application-setting.services';
import {ApplicationSetting} from '../../shared/model/application-setting/application-setting.model';
import {SettingApiServices} from '../../shared/service/setting/setting-api.services';
import {Setting} from '../../shared/model/setting/setting.model';
import { filter, pairwise } from 'rxjs/operators';
import {Application} from '../../shared/model/application/application.model';
import {ApplicationApiService} from '../../shared/service/application/application-api.service';
import {SnackBarService} from '../../shared/service/snack-bar.service';

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
  applications: Application[];
  private previousUrl: string = undefined;
  private currentUrl: string = undefined;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private appSettingService: ApplicationSettingApiServices,
              private settingService: SettingApiServices,
              private applicationService: ApplicationApiService,
              private snackBarService: SnackBarService) {
  }

  ngOnInit(): void {
    this.loadSettings();
    this.loadApplications();
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.load(this.id);
        this.isChangeApplicationSetting = true;
      }
    });
    this.formInitialization();

    this.router.events
      .pipe(filter((e: any) => e instanceof RoutesRecognized),
        pairwise()
      ).subscribe((e: any) => {
      console.log(e[0].urlAfterRedirects); // previous url
    });
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
      applicationId: new FormControl( 0, [Validators.required]),
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
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  private addAppsetting(appSetting: ApplicationSetting): void {
    this.appSettingService.add(appSetting)
      .subscribe(() => {
        this.formInitialization();
        console.log('Добавил');
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
    this.applicationService.getSApplications()
      .subscribe((applications: Application[]) => {
        this.applications = applications;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
