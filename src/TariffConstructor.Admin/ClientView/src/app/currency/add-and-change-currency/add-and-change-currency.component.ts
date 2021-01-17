import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ReactiveFormsModule} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {Currency} from '../../shared/model/currency/currency.model';
import {CurrencyService} from '../../shared/service/currency/currency.service';

@Component({
  selector: 'app-add-and-change-currency',
  templateUrl: './add-and-change-currency.component.html',
  styleUrls: ['./add-and-change-currency.component.css']
})
export class AddAndChangeCurrencyComponent implements OnInit {
  isChangeCurrency = false;
  id: number;
  form: FormGroup;
  currency: Currency;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private currencyService: CurrencyService,
              private snackBarService: SnackBarService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.load(this.id);
        this.isChangeCurrency = true;
      }
    });
    this.formInitialization();
  }

  private load(id: number): void {
    this.currencyService.get(id)
      .subscribe((currency: Currency) => {
        this.currency = currency;
        this.form.patchValue(currency);
        console.log('currency: ', currency);
      });
  }

  private formInitialization(): void {
    this.form = new FormGroup({
      code: new FormControl('',  [Validators.required,
                                        Validators.minLength(3),
                                        Validators.maxLength(3),
                                        Validators.pattern('[0-9]*')]),
      name: new FormControl('', [Validators.required,
                                                      Validators.minLength(3),
                                                      Validators.maxLength(3),
                                                      Validators.pattern('[a-zA-Z]*')])
    });
  }

  action(): void {
    this.currency = this.form.getRawValue();
    this.currency.id = this.id;
    this.currency.name = this.currency.name.toUpperCase();
    console.log('currency: ', this.currency);
    if (this.isChangeCurrency){
      this.updateAppSetting(this.currency);
    }
    else {
      this.addAppsetting(this.currency);
    }
  }

  private updateAppSetting(currency: Currency): void {
    this.currencyService.update(currency)
      .subscribe( () => {
        this.formInitialization();
        this.router.navigate(['currency']);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  private addAppsetting(currency: Currency): void {
    this.currencyService.add(currency)
      .subscribe(() => {
        this.formInitialization();
        console.log('Добавил');
      }, error => {
        console.log(error);
        console.log('TYPE', error.type);
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

}
