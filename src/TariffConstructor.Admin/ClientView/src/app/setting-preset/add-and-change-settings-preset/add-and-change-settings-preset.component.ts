import {Component, OnInit, QueryList, ViewChild, ViewChildren} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {SettingsPreset} from '../../shared/model/setting/settings-preset.model';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SettingsPresetApiServices} from '../../shared/service/setting/settings-preset.service';
import {MatDialog} from '@angular/material/dialog';
import {AddBillingSettingPresetComponent} from './add-billing-setting-preset/add-billing-setting-preset.component';
import {AddApplicationSettingPresetsComponent} from './add-application-setting-presets/add-application-setting-presets.component';
import {ApplicationSettingPreset} from '../../shared/model/application-setting/application-setting-preset.model';
import {MatTable} from '@angular/material/table';
import {BillingsSettingPreset} from '../../shared/model/billing-setting/billings-setting-preset.model';

@Component({
  selector: 'app-add-and-change-settings-preset',
  templateUrl: './add-and-change-settings-preset.component.html',
  styleUrls: ['./add-and-change-settings-preset.component.css']
})
export class AddAndChangeSettingsPresetComponent implements OnInit {
  isChange = false;
  id: number;
  form: FormGroup;
  settingsPreset: SettingsPreset;
  applicationSettingsPreset: ApplicationSettingPreset[] = [];
  billingSettingsPreset: BillingsSettingPreset[] = [];
  displayedColumnsAppSettings: string[] = ['id', 'applicationSettingId', 'defaultValue', 'isRequired', 'isReadOnly', 'isHidden', 'action'];
  displayedColumnsBillingSettings: string[] = ['id', 'billingSettingId', 'defaultValue', 'isRequired', 'isReadOnly', 'isHidden', 'action'];
  @ViewChild('table1') appSettingTable: MatTable<ApplicationSettingPreset>;
  // @ViewChildren(MatTable) appSettingTable !: QueryList<MatTable<ApplicationSettingPreset>>;
  @ViewChild('table2') billingSettingTable: MatTable<BillingsSettingPreset>;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private settingsPresetService: SettingsPresetApiServices,
              public dialog: MatDialog) { }

  ngOnInit(): void {
    this.settingsPreset = new SettingsPreset();
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

  formInitialization(): void{
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
    });
  }

  action(): void {
    this.settingsPreset = this.form.getRawValue();
    this.settingsPreset.id = this.id;
    console.log('setting: ', this.settingsPreset);
    if (this.isChange){
      this.updateSetting(this.settingsPreset);
    }
    else {
      this.addSetting(this.settingsPreset);
    }
  }

  load(id: number): void {
    this.settingsPresetService.get(id)
      .subscribe( (settingsPreset: SettingsPreset) => {
        this.settingsPreset = settingsPreset;
        this.form.patchValue(settingsPreset);
        this.applicationSettingsPreset = this.settingsPreset.applicationSettingsPresets;
        this.billingSettingsPreset = this.settingsPreset.billingsSettingPresets;
        this.appSettingTable.renderRows();
        this.billingSettingTable.renderRows();
      }, error => {
        console.log(error);
      });
  }

  addSetting(settingsPreset: SettingsPreset): void {
    settingsPreset.applicationSettingsPresets = this.applicationSettingsPreset;
    settingsPreset.billingsSettingPresets = this.billingSettingsPreset;
    console.log('add settingsPreset', settingsPreset);
    this.settingsPresetService.add(settingsPreset)
      .subscribe(() => {
        console.log('При добавлении сервер ответил: Ok');
        this.formInitialization();
      });
  }

  updateSetting(settingsPreset: SettingsPreset): void {
    settingsPreset.applicationSettingsPresets = this.applicationSettingsPreset;
    settingsPreset.billingsSettingPresets = this.billingSettingsPreset;
    console.log('change settingsPreset', settingsPreset);
    this.settingsPresetService.update(settingsPreset)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['/settingsPreset']);
      });
  }

  openAddApplicationSettingPreset(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddApplicationSettingPresetsComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('applicationSettingPreset === undefined');
      }
      else{
        const applicationSettingPreset = result;
        this.applicationSettingsPreset.push(applicationSettingPreset);
        this.appSettingTable.renderRows();
      }
    });
  }

  openAddBillingSettingPreset(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddBillingSettingPresetComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('billingSettingsPreset === undefined');
      }
      else{
        const billingSettingPreset = result;
        this.billingSettingsPreset.push(billingSettingPreset);
        console.log('billingSettingsPreset: ', this.billingSettingsPreset);
        this.billingSettingTable.renderRows();
      }
    });
  }

  deleteAppSettings(applicationSettingPreset: ApplicationSettingPreset): void{
    const index = this.applicationSettingsPreset.indexOf(applicationSettingPreset, 0);
    if (index > -1) {
      this.applicationSettingsPreset.splice(index, 1);
    }
    this.appSettingTable.renderRows();
  }

  deleteBillingSettings(billingSettingPreset: BillingsSettingPreset): void{
    const index = this.billingSettingsPreset.indexOf(billingSettingPreset, 0);
    if (index > -1) {
      this.billingSettingsPreset.splice(index, 1);
    }
    this.billingSettingTable.renderRows();
  }

}
