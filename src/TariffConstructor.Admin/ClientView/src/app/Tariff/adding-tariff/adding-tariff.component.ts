import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Tariff} from '../../shared/model/tariff/tariff.model';
import { MatDialog } from '@angular/material/dialog';
import {AddIncludedProductComponent} from '../add-included-product/add-included-product.component';
import {AddPriceComponent} from '../add-price/add-price.component';
import {IncludedProductInTariff} from '../../shared/model/tariff/included-product-In-tariff.model';
import {AddIncludedProductOptionComponent} from '../add-included-product-option/add-included-product-option.component';
import {Price} from '../../shared/model/value-object/price.model';
import {TariffAdvancePrice} from '../../shared/model/tariff/tariff-advance-price.model';
import {IncludedProductOptionInTariff} from '../../shared/model/tariff/included-product-option-in-tariff.model';
import {TariffToContractKindBinding} from '../../shared/model/tariff/tariff-to-contract-kind-binding.model';
import {MatTable} from '@angular/material/table';
import {ApplicationSettingPreset} from '../../shared/model/application-setting/application-setting-preset.model';
import {SettingsPreset} from '../../shared/model/setting/settings-preset.model';
import {TariffService} from '../../shared/service/tariff/tariff.service';
import {TariffPrice} from '../../shared/model/tariff/tariff-price.model';
import {AddApplicationSettingPresetsComponent} from '../../setting-preset/add-and-change-settings-preset/add-application-setting-presets/add-application-setting-presets.component';
import {AddAdvancePriceComponent} from '../add-advance-price/add-advance-price.component';
import {AddContractKindBindingComponent} from '../add-contract-kind-binding/add-contract-kind-binding.component';
import {SnackBarService} from '../../shared/service/snack-bar.service';

@Component({
  selector: 'app-adding-tariff',
  templateUrl: './adding-tariff.component.html',
  styleUrls: ['./adding-tariff.component.css']
})

export class AddingTariffComponent implements OnInit {
  isChangeTariff = false;
  form: FormGroup;
  tariff: Tariff;
  prices: TariffPrice[] = [];
  advancePrices: TariffAdvancePrice[] = [];
  includedProducts: IncludedProductInTariff[] = [];
  includedProductOptions: IncludedProductOptionInTariff[] = [];
  contractKindBindings: TariffToContractKindBinding[] = [];
  id: number;
  columnsInIncludedProducts = ['productId', 'relativeWeight'];
  priceTableColumns = [];
  tariffAdvancePrice = [];
  includedProductInTariff = [];
  includedProductOptionInTariff = [];
  tariffToContractKindBinding = [];
  @ViewChild('priceTable') priceTable: MatTable<Price>;
  @ViewChild('advancePriceTable') advancePriceTable: MatTable<TariffAdvancePrice>;
  @ViewChild('IncludedProductInTariffTable') includedProductInTariffTable: MatTable<IncludedProductInTariff>;
  @ViewChild('IncludedProductOptionInTariffTable') includedProductOptionInTariffTable: MatTable<IncludedProductOptionInTariff>;
  @ViewChild('TariffToContractKindBindingTable') tariffToContractKindBindingTable: MatTable<TariffToContractKindBinding>;
  constructor(private http: HttpClient,
              private router: Router,
              private route: ActivatedRoute,
              public dialog: MatDialog,
              private tariffService: TariffService,
              private snackBarService: SnackBarService) {
  }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.load(this.id);
        this.isChangeTariff = true;
      }
    });
    this.tariff = new Tariff();
    this.formInitialization();
  }

  formInitialization(): void {
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      isArchived: new FormControl( false),
      testPeriod: new FormGroup({
        value: new FormControl(),
        unit: new FormControl()
      }),
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
  }

  load(id: number): void {
    this.tariffService.get(id)
      .subscribe( (tariff: Tariff) => {
        this.tariff = tariff;
        this.form.patchValue(tariff);
        this.prices = this.tariff.prices;
        this.advancePrices = this.tariff.advancePrices;
        this.includedProducts = this.tariff.includedProducts;
        this.includedProductOptions = this.tariff.includedProductOptions;
        this.contractKindBindings = this.tariff.contractKindBindings;
        this.priceTable.renderRows();
        this.advancePriceTable.renderRows();
        this.includedProductInTariffTable.renderRows();
        this.includedProductOptionInTariffTable.renderRows();
        this.tariffToContractKindBindingTable.renderRows();
      }, error => {
        console.log(error);
      });
  }

  action(): void {
    this.tariff = this.form.getRawValue();
    this.tariff.id = this.id;
    console.log('tariff: ', this.tariff);
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
    this.tariffService.add(this.tariff)
      .subscribe(() =>
      {
        this.formInitialization();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  changeTariff(): void{
    this.tariffService.update(this.tariff)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['/tariff']);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  openAddPriceTariff(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddPriceComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('price === undefined');
      }
      else{
        const price = result;
        this.tariff.prices.push(price);
        this.priceTable.renderRows();
      }
    });
  }

  openAddAdvancePrice(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddAdvancePriceComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('advancePrice === undefined');
      }
      else{
        const advancePrice = result;
        this.tariff.advancePrices.push(advancePrice);
        this.advancePriceTable.renderRows();
      }
    });
  }

  openAddIncludedProduct(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddIncludedProductComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('includedProduct === undefined');
      }
      else{
        const includedProduct = result;
        this.tariff.includedProducts.push(includedProduct);
        this.includedProductInTariffTable.renderRows();
      }
    });
  }

  openAddIncludedProductOption(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddIncludedProductComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('includedProductOption === undefined');
      }
      else{
        const includedProductOption = result;
        this.tariff.includedProductOptions.push(includedProductOption);
        this.includedProductOptionInTariffTable.renderRows();
      }
    });
  }

  openAddContractKindBindings(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddContractKindBindingComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('contractKindBinding === undefined');
      }
      else{
        const contractKindBinding = result;
        this.tariff.contractKindBindings.push(contractKindBinding);
        this.tariffToContractKindBindingTable.renderRows();
      }
    });
  }
}
