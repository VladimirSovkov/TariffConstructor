import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {SnackBarService} from '../../../../shared/service/snack-bar.service';
import {SettingApiServices} from '../../../../shared/service/setting/setting-api.services';
import {BillingSetting} from '../../../../shared/model/billing-setting/billing-setting/billing-setting.model';
import {Setting} from '../../../../shared/model/setting/setting.model';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {BillingSettingApiServices} from '../../../../shared/service/billing-setting/billing-setting.service';

@Component({
  selector: 'app-add-billing-setting',
  templateUrl: './add-billing-setting.component.html',
  styleUrls: ['./add-billing-setting.component.css']
})
export class AddBillingSettingComponent implements OnInit {
  form: FormGroup;
  billingSetting: BillingSetting;
  settings: Setting[];
  constructor(public dialogRef: MatDialogRef<AddBillingSettingComponent>,
              private billingSettingService: BillingSettingApiServices,
              private snackBarService: SnackBarService,
              private settingService: SettingApiServices,
              private dialog: MatDialog) { }

  ngOnInit(): void {
    this.formInitialization();
    this.loadSetting();
  }

  private formInitialization(): void {
    this.form = new FormGroup({
      settingId: new FormControl('', [Validators.required]),
    });
  }

  public add(): void {
    this.billingSetting = this.form.getRawValue();
    this.billingSettingService.add(this.billingSetting)
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
