import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Price} from '../../shared/model/value-object/price.model';
import {ProlongationPeriod} from '../../shared/model/value-object/prolongation-period.model';
import {TariffPrice} from '../../shared/model/tariff/tariff-price.model';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {Tariff} from '../../shared/model/tariff/tariff.model';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {CurrencyService} from '../../shared/service/currency/currency.service';
import {Currency} from '../../shared/model/currency/currency.model';

@Component({
  selector: 'app-add-price',
  templateUrl: './add-price.component.html',
  styleUrls: ['./add-price.component.css']
})
export class AddPriceComponent implements OnInit {
  form: FormGroup;
  tariffPrice: TariffPrice = new TariffPrice();
  prolongationPeriod: ProlongationPeriod;
  currencies: Currency[] = [];
  constructor(public dialogRef: MatDialogRef<AddPriceComponent>,
              private snackBarService: SnackBarService,
              private currencyService: CurrencyService) { }

  ngOnInit(): void {
    this.initializationForm();
    this.loadCurrency();
  }

  private initializationForm(): void {
    this.form = new FormGroup({
      price: new FormGroup({
        value: new FormControl(0, [Validators.required, Validators.min(0)]),
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
