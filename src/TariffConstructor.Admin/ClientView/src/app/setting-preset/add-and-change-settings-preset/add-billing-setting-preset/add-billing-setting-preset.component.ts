import {Component, Inject, OnInit} from '@angular/core';
import {BillingsSettingPreset} from '../../../shared/model/billing-setting/billings-setting-preset.model';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from '@angular/material/dialog';
import {BillingSetting} from '../../../shared/model/billing-setting/billing-setting/billing-setting.model';
import {BillingSettingApiServices} from '../../../shared/service/billing-setting/billing-setting.service';
import {SnackBarService} from '../../../shared/service/snack-bar.service';
import {AddApplicationSettingComponent} from '../add-application-setting-presets/add-application-setting/add-application-setting.component';
import {AddBillingSettingComponent} from './add-billing-setting/add-billing-setting.component';
import {IncludedProductInTariff} from '../../../shared/model/tariff/included-product-In-tariff.model';

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
              private snackBar: SnackBarService,
              public dialog: MatDialog,
              @Inject(MAT_DIALOG_DATA) public data: BillingsSettingPreset[]) { }

  ngOnInit(): void {
    this.loadBillingSettings();
    this.initializationForm();
  }

  private initializationForm(): void {
    this.form = new FormGroup({
      billingSettingId: new FormControl('', [Validators.required]),
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
    this.billingSettingService.get(this.billingSettingPreset.billingSettingId)
      .subscribe((billingSetting: BillingSetting) =>{
        this.billingSettingPreset.billingSetting = billingSetting;
        this.billingSettingPreset.id = 0;
        console.log('billingSettingPreset: ', this.billingSettingPreset);
        this.dialogRef.close(this.billingSettingPreset);
      }, error => {
        this.snackBar.openErrorHttpSnackBar(error);
      });
  }

  private loadBillingSettings(): void {
    this.billingSettingService.getAll()
      .subscribe((billingSettings: BillingSetting[]) => {
        this.billingSettings = billingSettings.filter( ( el ) => !this.data.map(x => x.billingSettingId).includes( el.id ) );
      }, error => {
        this.snackBar.openErrorHttpSnackBar(error);
      });
  }

  openAddBillingSetting(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddBillingSettingComponent);
    dialogRef.afterClosed().subscribe(() => {
      this.loadBillingSettings();
    });
  }
}
