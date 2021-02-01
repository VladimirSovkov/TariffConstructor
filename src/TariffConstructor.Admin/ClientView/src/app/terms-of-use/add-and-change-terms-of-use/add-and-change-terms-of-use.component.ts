import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {TermsOfUse} from '../../shared/model/terms-of-use/terms-of-use.model';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {TermsOfUseApiService} from '../../shared/service/terms-of-use/terms-of-use-api.service';
import {SnackBarService} from '../../shared/service/snack-bar.service';

@Component({
  selector: 'app-add-and-change-terms-of-use',
  templateUrl: './add-and-change-terms-of-use.component.html',
  styleUrls: ['./add-and-change-terms-of-use.component.css']
})
export class AddAndChangeTermsOfUseComponent implements OnInit {
  isChange = false;
  id: number;
  form: FormGroup;
  termsOfUse: TermsOfUse;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private termsOfUseService: TermsOfUseApiService,
              private snackBarService: SnackBarService) { }

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
      documentName: new FormControl('', [Validators.required]),
    });
  }

  action(): void {
    this.termsOfUse = new TermsOfUse();
    this.termsOfUse = this.form.getRawValue();
    this.termsOfUse.id = this.id;
    console.log('termsOfUse: ', this.termsOfUse);
    if (this.isChange){
      this.updateTermsOfUse(this.termsOfUse);
    }
    else {
      this.addTermsOfUse(this.termsOfUse);
    }
  }

  load(id: number): void {
    this.termsOfUseService.get(id)
      .subscribe( (termsOfUse: TermsOfUse) => {
        this.termsOfUse = termsOfUse;
        this.form.patchValue(termsOfUse);
        console.log('termsOfUse: ', this.termsOfUse);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  addTermsOfUse(termsOfUse: TermsOfUse): void {
    this.termsOfUseService.add(termsOfUse)
      .subscribe(() => {
        this.formInitialization();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);

      });
  }

  updateTermsOfUse(termsOfUse: TermsOfUse): void {
    this.termsOfUseService.update(termsOfUse)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['/termsOfUse']);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

}
