import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Price} from '../../shared/model/value-object/price.model';
import {ProlongationPeriod} from '../../shared/model/value-object/prolongation-period.model';
import {TariffPrice} from '../../shared/model/TariffAggregate/tariff-price.model';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {Tariff} from '../../shared/model/TariffAggregate/tariff.model';

@Component({
  selector: 'app-add-price',
  templateUrl: './add-price.component.html',
  styleUrls: ['./add-price.component.css']
})
export class AddPriceComponent implements OnInit {
  formPeriod: FormGroup;
  formPrice: FormGroup;
  tariffPrice: TariffPrice;
  price: Price;
  period: ProlongationPeriod;
  prolongationPeriod: ProlongationPeriod;
  constructor(public dialogRef: MatDialogRef<AddPriceComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Tariff) { }

  ngOnInit(): void {
    this.formPeriod = new FormGroup({
      value: new FormControl( 0, [Validators.required]),
      unit: new FormControl('', [Validators.required])
    });

    this.formPrice = new FormGroup({
      value: new FormControl(0, [Validators.required]),
      currency: new FormControl('', [Validators.required])
    });
  }

  addPrice(): void{
    this.price =  this.formPrice.getRawValue();
    this.period = this.formPeriod.getRawValue();
    this.tariffPrice = new TariffPrice();
    this.tariffPrice = {
      id: 0,
      tariffId: (this.data.id === undefined) ? 0 : this.data.id,
      price: this.price,
      period: this.period,
    };
    this.data.prices.push(this.tariffPrice);

  }
}
