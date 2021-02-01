import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ProlongationPeriod} from '../../shared/model/value-object/prolongation-period.model';
import {Currency} from '../../shared/model/currency/currency.model';
import {MatDialogRef} from '@angular/material/dialog';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {CurrencyService} from '../../shared/service/currency/currency.service';
import {TariffAdvancePrice} from '../../shared/model/tariff/tariff-advance-price.model';
import {TariffPrice} from '../../shared/model/tariff/tariff-price.model';

@Component({
  selector: 'app-add-advanced-price',
  templateUrl: './add-advanced-price.component.html',
  styleUrls: ['./add-advanced-price.component.css']
})
export class AddAdvancedPriceComponent implements OnInit {
  form: FormGroup;
  tariffPrice: TariffPrice = new TariffPrice();
  prolongationPeriod: ProlongationPeriod;
  currencies: Currency[] = [];
  constructor(public dialogRef: MatDialogRef<AddAdvancedPriceComponent>,
              private snackBarService: SnackBarService,
              private currencyService: CurrencyService) { }

  ngOnInit(): void {
    this.initializationForm();
    this.loadCurrency();
  }

  private initializationForm(): void {
    this.form = new FormGroup({
      price: new FormGroup({
        value: new FormControl(0, [Validators.required, Validators.min(0.000001)]),
        currency: new FormControl('', [Validators.required]),
      }),
      period: new FormGroup({
        value: new FormControl(0, [Validators.required, Validators.min(1), Validators.pattern('\\d*')]),
        periodUnit: new FormControl(0, [Validators.required]),
      })
    });
  }

  close(): void {
    this.tariffPrice = this.form.getRawValue();
    this.tariffPrice.id = 0;
    console.log('tariffPrice: ', this.tariffPrice);
    this.dialogRef.close(this.tariffPrice);
  }

  private loadCurrency(): void {
    this.currencyService.getCurrencies()
      .subscribe((currencies: Currency[]) => {
        this.currencies = currencies;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

}
