import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Setting} from '../../shared/model/setting/setting.model';
import {SettingApiServices} from '../../shared/service/setting/setting-api.services';

@Component({
  selector: 'app-add-change-setting',
  templateUrl: './add-change-setting.component.html',
  styleUrls: ['./add-change-setting.component.css']
})
export class AddChangeSettingComponent implements OnInit {
  isChangeSetting = false;
  id: number;
  form: FormGroup;
  setting: Setting;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private settingService: SettingApiServices) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.load(this.id);
        this.isChangeSetting = true;
      }
    });
    this.formInitialization();
  }

  formInitialization(): void{
    this.form = new FormGroup({
      type: new FormControl('', [Validators.required]),
      name: new FormControl('', ),
      code: new FormControl('', [Validators.required]),
      description: new FormControl(''),
      isComputing: new FormControl(false)
    });
  }

  action(): void {
    this.setting = new Setting();
    this.setting = this.form.getRawValue();
    this.setting.id = this.id;
    console.log('setting: ', this.setting);
    if (this.isChangeSetting){
      this.updateSetting(this.setting);
    }
    else {
      this.addSetting(this.setting);
    }
  }

  load(id: number): void {
    this.settingService.get(id)
      .subscribe( (setting: Setting) => {
        this.setting = setting;
        this.form.patchValue(setting);
        console.log('setting: ', this.setting);
      });
  }

  addSetting(setting: Setting): void {
    this.settingService.add(setting)
      .subscribe(() => {
        console.log('При добавлении сервер ответил: Ok');
        this.formInitialization();
      });
  }

  updateSetting(setting: Setting): void {
    this.settingService.update(setting)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['/setting']);
      });
  }
}
