import {Component, OnInit, ViewChild} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {MatTable} from '@angular/material/table';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {MatDialog} from '@angular/material/dialog';
import {ProductOptionTariff} from '../../shared/model/product-option-tariff/product-option-tariff.model';
import {ProductOptionTariffPrice} from '../../shared/model/product-option-tariff/product-option-tariff-price.model';
import {ProductOptionTariffService} from '../../shared/service/product-option-tariff/product-option-tariff.service';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {AddProductOptionTariffPriceComponent} from './add-product-option-tariff-price/add-product-option-tariff-price.component';
import {ProductOption} from '../../shared/model/productOption/product-option.model';
import {ProductOptionService} from '../../shared/service/product-option/product-option.service';

@Component({
  selector: 'app-add-and-change-product-option-tariff',
  templateUrl: './add-and-change-product-option-tariff.component.html',
  styleUrls: ['./add-and-change-product-option-tariff.component.css']
})
export class AddAndChangeProductOptionTariffComponent implements OnInit {
  isChange = false;
  id: number;
  form: FormGroup;
  productOptionTariff: ProductOptionTariff;
  productOptions: ProductOption[];
  productOptionTariffPrices: ProductOptionTariffPrice[] = [];
  displayedColumnsAppSettings: string[] = [ 'priceCurrency', 'priceValue', 'periodPeriodUnit', 'periodValue', 'action'];
  @ViewChild('tablePrice') productOptionTariffPriceTable: MatTable<ProductOptionTariffPrice>;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private productOptionTariffService: ProductOptionTariffService,
              public dialog: MatDialog,
              private snackBarService: SnackBarService,
              private productOptionService: ProductOptionService) { }

  ngOnInit(): void {
    this.productOptionTariff = new ProductOptionTariff();
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.load(this.id);
        this.isChange = true;
      }
    });
    this.formInitialization();
    this.loadProductOptions();
  }

  formInitialization(): void{
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      productOptionId: new FormControl('', [Validators.required]),
    });
  }

  action(): void {
    this.productOptionTariff = this.form.getRawValue();
    this.productOptionTariff.id = this.id;
    this.productOptionTariff.prices = this.productOptionTariffPrices;
    console.log('productOptionTariff: ', this.productOptionTariff);
    if (this.isChange){
      this.update(this.productOptionTariff);
    }
    else {
      this.addProductOptionTariff(this.productOptionTariff);
    }
  }

  load(id: number): void {
    this.productOptionTariffService.get(id)
      .subscribe( (productOptionTariff: ProductOptionTariff) => {
        this.productOptionTariff = productOptionTariff;
        this.form.patchValue(productOptionTariff);
        this.productOptionTariffPrices = this.productOptionTariff.prices;
        this.productOptionTariffPriceTable.renderRows();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  loadProductOptions(): void {
    this.productOptionService.getAll()
      .subscribe( (productOptions: ProductOption[]) => {
        this.productOptions = productOptions;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  addProductOptionTariff(productOptionTariff: ProductOptionTariff): void {
    console.log('add productOptionTariff', productOptionTariff);
    this.productOptionTariffService.add(productOptionTariff)
      .subscribe(() => {
        this.formInitialization();
        this.productOptionTariffPrices = [];
        this.productOptionTariffPriceTable.renderRows();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  update(productOptionTariff: ProductOptionTariff): void {
    this.productOptionTariffService.update(productOptionTariff)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['/productOptionTariff']);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  openAddProductOptionTariffPrice(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddProductOptionTariffPriceComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('productOptionTariffPrice === undefined');
      }
      else{
        const price: ProductOptionTariffPrice = result;
        if (this.productOptionTariffPrices.some(x =>
          x.period.periodUnit === price.period.periodUnit &&
          x.period.value === price.period.value &&
          x.price.currency === price.price.currency))
        {
          this.snackBarService.openErrorHttpSnackBar('Цена с такой валютой за указанный период уже существует!');
        }
        else {
          this.productOptionTariffPrices.push(price);
          this.productOptionTariffPriceTable.renderRows();
        }
      }
    });
  }

  deleteProductOptionPrice(productOptionTariffPrice: ProductOptionTariffPrice): void{
    const index = this.productOptionTariffPrices.indexOf(productOptionTariffPrice, 0);
    if (index > -1) {
      this.productOptionTariffPrices.splice(index, 1);
    }
    this.productOptionTariffPriceTable.renderRows();
  }

  parserPeriodUnit(id: number): any {
    return PeriodUnit[id];
  }
}

enum PeriodUnit {
  Month = 0,
  QuarterOfTheYear = 1,
  HalfYear = 2,
  Year = 3
}
