import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Price} from '../../shared/model/value-object/price.model';
import {ProlongationPeriod} from '../../shared/model/value-object/prolongation-period.model';
import {TariffAdvancePrice} from '../../shared/model/tariff/tariff-advance-price.model';

@Component({
  selector: 'app-add-advance-price',
  templateUrl: './add-advance-price.component.html',
  styleUrls: ['./add-advance-price.component.css']
})
export class AddAdvancePriceComponent implements OnInit {
  form: FormGroup;
  advancePrice: TariffAdvancePrice;
  prolongationPeriod: ProlongationPeriod;
  constructor() { }

  ngOnInit(): void {
    this.form = new FormGroup({
      priceValue: new FormControl(0, [Validators.required]),
      priceCurrency: new FormControl('', [Validators.required]),
      prolongationPeriodValue: new FormControl( 0, [Validators.required]),
      prolongationPeriodUnit: new FormControl('', [Validators.required])
    });
  }

  addAdvancePrice(): void{
    console.log('advancePrice: ', this.advancePrice);
  }
}
