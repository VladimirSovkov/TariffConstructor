import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from '@angular/material/dialog';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ApplicationSettingPreset} from '../../../shared/model/application-setting/application-setting-preset.model';
import {ApplicationSetting} from '../../../shared/model/application-setting/application-setting.model';
import {ApplicationSettingApiServices} from '../../../shared/service/application-setting/application-setting.services';
import {SnackBarService} from '../../../shared/service/snack-bar.service';
import {AddChangeApplicationSettingComponent} from '../../../application-setting/add-change-application-setting/add-change-application-setting.component';

@Component({
  selector: 'app-add-application-setting-presets',
  templateUrl: './add-application-setting-presets.component.html',
  styleUrls: ['./add-application-setting-presets.component.css']
})
export class AddApplicationSettingPresetsComponent implements OnInit {
  appSettingForm: FormGroup;
  applicationSettingPreset: ApplicationSettingPreset;
  applicationSettings: ApplicationSetting[];
  constructor(public dialogRef: MatDialogRef<AddApplicationSettingPresetsComponent>,
              private applicationSettingService: ApplicationSettingApiServices,
              private snackBarService: SnackBarService,
              public dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadApplicationSetting();
    this.initializationAppSettingForm();
  }

  private initializationAppSettingForm(): void {
    this.appSettingForm = new FormGroup({
      applicationSettingId: new FormControl(0, [Validators.required]),
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
    this.applicationSettingPreset = this.appSettingForm.getRawValue();
    this.applicationSettingPreset.id = 0;
    console.log('applicationSettingPreset: ', this.applicationSettingPreset);
    this.dialogRef.close(this.applicationSettingPreset);
  }

  private loadApplicationSetting(): void {
    this.applicationSettingService.getAll()
      .subscribe( (applicationSettings: ApplicationSetting[]) => {
        this.applicationSettings = applicationSettings;
    }, error => {
        this.snackBarService.openErrorSnackBar(error);
    });
  }

  openAddApplicationSetting(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddChangeApplicationSettingComponent);
    dialogRef.afterClosed().subscribe(() => {
      this.loadApplicationSetting();
    });
  }
}
