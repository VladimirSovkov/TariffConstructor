import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {SnackBarService} from '../../../shared/service/snack-bar.service';
import {ProductOptionTariffPrice} from '../../../shared/model/product-option-tariff/product-option-tariff-price.model';
import validate = WebAssembly.validate;
import {CurrencyService} from '../../../shared/service/currency/currency.service';
import {Currency} from '../../../shared/model/currency/currency.model';

@Component({
  selector: 'app-add-product-option-tariff-price',
  templateUrl: './add-product-option-tariff-price.component.html',
  styleUrls: ['./add-product-option-tariff-price.component.css']
})
export class AddProductOptionTariffPriceComponent implements OnInit {
  form: FormGroup;
  productOptionTariffPrice: ProductOptionTariffPrice;
  currencies: Currency[];
  constructor(public dialogRef: MatDialogRef<AddProductOptionTariffPriceComponent>,
              private snackBarService: SnackBarService,
              public dialog: MatDialog,
              private currencyService: CurrencyService) { }

  ngOnInit(): void {
    this.initializationAppSettingForm();
    this.loadCurrency();
  }

  private initializationAppSettingForm(): void {
    this.form = new FormGroup({
      price: new FormGroup({
        value: new FormControl(0, [Validators.required, Validators.min(0)]),
        currency: new FormControl('', [Validators.required]),
      }),
      period: new FormGroup({
        value: new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern('\\d*')]),
        periodUnit: new FormControl(0, [Validators.required]),
      }),
    });
  }

  close(): void {
    this.productOptionTariffPrice = this.form.getRawValue();
    this.productOptionTariffPrice.id = 0;
    console.log('productOptionTariffPrice: ', this.productOptionTariffPrice);
    this.dialogRef.close(this.productOptionTariffPrice);
  }

  private loadCurrency(): void {
    this.currencyService.getCurrencies()
      .subscribe( (currencies: Currency[]) => {
        this.currencies = currencies;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
