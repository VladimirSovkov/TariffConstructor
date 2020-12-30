import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Tariff} from '../../shared/model/TariffAggregate/tariff.model';
import { MatDialog } from '@angular/material/dialog';
import {AddIncludedProductComponent} from '../add-included-product/add-included-product.component';
import {AddPriceComponent} from '../add-price/add-price.component';
import {IncludedProductInTariff} from '../../shared/model/TariffAggregate/included-product-In-tariff.model';
import {AddIncludedProductOptionComponent} from '../add-included-product-option/add-included-product-option.component';

@Component({
  selector: 'app-adding-tariff',
  templateUrl: './adding-tariff.component.html',
  styleUrls: ['./adding-tariff.component.css']
})

export class AddingTariffComponent implements OnInit {
  isChangeTariff = false;
  panelOpenState = false;
  form: FormGroup;
  tariff: Tariff;
  includedProducts: IncludedProductInTariff[] = [];
  id: number;
  columnsInIncludedProducts = ['productId', 'relativeWeight'];
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
    });
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      isArchived: new FormControl( false),
      valueTestPeriod: new FormControl( 0),
      accountingName: new FormControl('', [Validators.required]),
      awaitingPaymentStrategy: new FormControl('', [Validators.required]),
      accountingTariffId: new FormControl(''),
      settingsPresetId: new FormControl( 0),
      termsOfUseId: new FormControl( 0),
      isAcceptanceRequired: new FormControl( false),
      isGradualFinishAvailable: new FormControl( false),
      paymentType: new FormControl('0', [Validators.required]),
      unitTestPeriod: new FormControl('0')
    });
    this.tariff = new Tariff();
    this.tariff.unitTestPeriod = '0';
    this.formInitialization();
  }

  formInitialization(): void {
    if (this.id)
    {
      this.load(this.id);
      this.isChangeTariff = true;
    }
  }

  load(id: number): void {
    this.http.get<Tariff>('http://localhost:4401/test/getTariff?id=' +  this.id)
      .subscribe( (tariff: Tariff)  => {
          this.tariff = tariff;
          this.form.patchValue(this.tariff);
          console.log(this.tariff);
        });
  }

  action(): void {
    this.tariff = this.form.getRawValue();
    this.tariff.includedProducts = this.includedProducts;
    if (this.isChangeTariff)
    {
      this.changeTariff();
    }
    else
    {
      this.addTariff();
    }
  }

  addTariff(): void {
    console.log('tariff: ', this.tariff);
    this.http.post('http://localhost:4401/tariff/add',  this.tariff)
     .subscribe(todo => {
       console.log('todo', todo);
       this.form.reset();
      });
  }

  changeTariff(): void{
    this.http.post('http://localhost:4401/tariff/changeTariff',  this.form.value)
      .subscribe(todo => {
        console.log('todo', todo);
        this.form.reset();
      });
  }

  openDialog(type: string): void {
    let dialogRef;
    if (type === 'Product') {
      dialogRef = this.dialog.open(AddIncludedProductComponent, {
        data: this.tariff
      });
    }
    else if (type === 'ProductOption'){
      dialogRef = this.dialog.open(AddIncludedProductOptionComponent, {
        data: this.tariff
      });
    }
    else if (type === 'Price')
    {
      dialogRef = this.dialog.open(AddPriceComponent, {
        data: this.tariff
      });
    }
    else if (type === 'AdvancePrice')
    {
      dialogRef = this.dialog.open(AddPriceComponent);
    }
    else if (type === 'ContractKindBindings')
    {
      dialogRef = this.dialog.open(AddIncludedProductComponent);
    }
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('tariff === undefined');
      }
      else{
        this.tariff = result;
        this.includedProducts = this.tariff.includedProducts;
        console.log('tariff: ', this.tariff);
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/tariff']);
  }

  test(): void{
    this.panelOpenState = false;
    console.log('this.panelOpenState = ', this.panelOpenState);
  }
}
