import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Application} from '../../shared/model/application/application.model';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {ApplicationApiService} from '../../shared/service/application/application-api.service';
import {Setting} from '../../shared/model/setting/setting.model';

@Component({
  selector: 'app-add-and-change-application',
  templateUrl: './add-and-change-application.component.html',
  styleUrls: ['./add-and-change-application.component.css']
})
export class AddAndChangeApplicationComponent implements OnInit {
  isChange = false;
  id: number;
  form: FormGroup;
  application: Application;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private applicationService: ApplicationApiService) { }

  ngOnInit(): void {
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
      publicId: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
    });
  }

  action(): void {
    this.application = new Application();
    this.application = this.form.getRawValue();
    this.application.id = this.id;
    console.log('application: ', this.application);
    if (this.isChange){
      this.updateApplication(this.application);
    }
    else {
      this.addApplication(this.application);
    }
  }

  load(id: number): void {
    this.applicationService.get(id)
      .subscribe( (application: Application) => {
        this.application = application;
        this.form.patchValue(application);
        console.log('application: ', this.application);
      });
  }

  addApplication(application: Application): void {
    this.applicationService.add(application)
      .subscribe(() => {
        console.log('При добавлении сервер ответил: Ok');
        this.formInitialization();
      });
  }

  updateApplication(application: Application): void {
    this.applicationService.update(application)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['/application']);
      });
  }

}
