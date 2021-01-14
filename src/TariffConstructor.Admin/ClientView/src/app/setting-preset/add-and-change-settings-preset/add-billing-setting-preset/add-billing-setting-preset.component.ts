import { Component, OnInit } from '@angular/core';
import {BillingsSettingPreset} from '../../../shared/model/billing-setting/billings-setting-preset.model';
import {FormControl, FormGroup} from '@angular/forms';
import {MatDialogRef} from '@angular/material/dialog';
import {BillingSetting} from '../../../shared/model/billing-setting/billing-setting/billing-setting.model';
import {BillingSettingApiServices} from '../../../shared/service/billing-setting/billing-setting.service';
import {SnackBarService} from '../../../shared/service/snack-bar.service';

@Component({
  selector: 'app-add-billing-setting-preset',
  templateUrl: './add-billing-setting-preset.component.html',
  styleUrls: ['./add-billing-setting-preset.component.css']
})
export class AddBillingSettingPresetComponent implements OnInit {
  billingSettingPreset: BillingsSettingPreset;
  billingSettings: BillingSetting[];
  form: FormGroup;
  constructor(public dialogRef: MatDialogRef<AddBillingSettingPresetComponent>,
              private billingSettingService: BillingSettingApiServices,
              private snackBar: SnackBarService) { }

  ngOnInit(): void {
    this.loadBillingSettings();
    this.initializationForm();
  }

  private initializationForm(): void {
    this.form = new FormGroup({
      billingSettingId: new FormControl(),
      value: new FormGroup({
        defaultValue: new FormControl(''),
        minValue: new FormControl(''),
        maxValue: new FormControl(''),
      }),
      isRequired: new FormControl(false),
      isReadOnly: new FormControl(false),
      isHidden: new FormControl(false),
    });
  }

  close(): void {
    this.billingSettingPreset = this.form.getRawValue();
    this.billingSettingPreset.id = 0;
    console.log('billingSettingPreset: ', this.billingSettingPreset);
    this.dialogRef.close(this.billingSettingPreset);
  }

  private loadBillingSettings(): void {
    this.billingSettingService.getAll()
      .subscribe((billingSettings: BillingSetting[]) => {
        this.billingSettings = billingSettings;
      }, error => {
        this.snackBar.openErrorSnackBar(error);
      });
  }
}
