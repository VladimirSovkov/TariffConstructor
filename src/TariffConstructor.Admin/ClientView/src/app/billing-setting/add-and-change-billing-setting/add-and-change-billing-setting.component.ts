import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {BillingSetting} from '../../shared/model/billing-setting/billing-setting/billing-setting.model';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {BillingSettingApiServices} from '../../shared/service/billing-setting/billing-setting.service';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {Setting} from '../../shared/model/setting/setting.model';
import {SettingApiServices} from '../../shared/service/setting/setting-api.services';

@Component({
  selector: 'app-add-and-change-billing-setting',
  templateUrl: './add-and-change-billing-setting.component.html',
  styleUrls: ['./add-and-change-billing-setting.component.css']
})
export class AddAndChangeBillingSettingComponent implements OnInit {
  isChange = false;
  id: number;
  form: FormGroup;
  billingSetting: BillingSetting;
  settings: Setting[];
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private billingSettingService: BillingSettingApiServices,
              private snackBarService: SnackBarService,
              private settingService: SettingApiServices) { }

  ngOnInit(): void {
    this.loadSetting();
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.load(this.id);
        this.isChange = true;
      }
    });
    this.formInitialization();
  }

  private load(id: number): void {
    this.billingSettingService.get(id)
      .subscribe((setting: BillingSetting) => {
        this.billingSetting = setting;
        this.form.patchValue(setting);
        console.log('billingSetting: ', setting);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  private formInitialization(): void {
    this.form = new FormGroup({
      settingId: new FormControl(0, [Validators.required]),
    });
  }

  action(): void {
    this.billingSetting = this.form.getRawValue();
    this.billingSetting.id = this.id;
    console.log('billingSetting: ', this.billingSetting);
    if (this.isChange){
      this.update(this.billingSetting);
    }
    else {
      this.add(this.billingSetting);
    }
  }

  private update(billingSetting: BillingSetting): void {
    this.billingSettingService.update(billingSetting)
      .subscribe( () => {
        this.formInitialization();
        this.router.navigate(['billingSetting']);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  private add(billingSetting: BillingSetting): void {
    this.billingSettingService.add(billingSetting)
      .subscribe(() => {
        this.formInitialization();
        console.log('Добавил');
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  private loadSetting(): void{
    this.settingService.getSettings()
      .subscribe((settings: Setting[]) => {
        this.settings = settings;
      });
  }

}
