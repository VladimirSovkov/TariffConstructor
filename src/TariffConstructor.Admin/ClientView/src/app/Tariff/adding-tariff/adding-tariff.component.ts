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
import {TermsOfUse} from '../../shared/model/terms-of-use/terms-of-use.model';
import {SettingsPresetApiServices} from '../../shared/service/setting/settings-preset.service';
import {TermsOfUseApiService} from '../../shared/service/terms-of-use/terms-of-use-api.service';

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
  settingsPresets: SettingsPreset[] = [];
  termsOfUses: TermsOfUse[] = [];
  id: number;
  priceTableColumns = ['priceCurrency', 'priceValue', 'periodPeriodUnit', 'periodValue', 'action'];
  includedProductInTariffColumns = ['product', 'relativeWeight', 'action'];
  includedProductOptionInTariffColumns = ['productOptionId', 'quantity',  'action'];
  tariffToContractKindBindingColumns = ['contractKindId', 'action'];
  @ViewChild('priceTable') priceTable: MatTable<TariffPrice>;
  @ViewChild('advancePriceTable') advancePriceTable: MatTable<TariffAdvancePrice>;
  @ViewChild('IncludedProductInTariffTable') includedProductInTariffTable: MatTable<IncludedProductInTariff>;
  @ViewChild('IncludedProductOptionInTariffTable') includedProductOptionInTariffTable: MatTable<IncludedProductOptionInTariff>;
  @ViewChild('TariffToContractKindBindingTable') tariffToContractKindBindingTable: MatTable<TariffToContractKindBinding>;
  constructor(private http: HttpClient,
              private router: Router,
              private route: ActivatedRoute,
              public dialog: MatDialog,
              private tariffService: TariffService,
              private snackBarService: SnackBarService,
              private settingsPresetService: SettingsPresetApiServices,
              private termsOfUseService: TermsOfUseApiService) {
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
    this.loadSettingsPresets();
    this.loadTermsOfUse();
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

  loadSettingsPresets(): void {
    this.settingsPresetService.getAll()
      .subscribe((settingsPresets: SettingsPreset[]) => {
        this.settingsPresets = settingsPresets;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  loadTermsOfUse(): void {
    this.termsOfUseService.getTermsOfUses()
      .subscribe((termsOfUses: TermsOfUse[]) => {
        this.termsOfUses = termsOfUses;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  action(): void {
    this.tariff = this.form.getRawValue();
    this.tariff.id = this.id;
    this.tariff.prices = this.prices;
    this.tariff.advancePrices = this.advancePrices;
    this.tariff.includedProducts = this.includedProducts;
    this.tariff.includedProductOptions = this.includedProductOptions;
    this.tariff.contractKindBindings = this.contractKindBindings;
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
      else {
        const price: TariffPrice = result;
        if (this.prices.some(x =>
          x.period.periodUnit === price.period.periodUnit &&
          x.period.value === price.period.value &&
          x.price.currency === price.price.currency))
        {
          this.snackBarService.openErrorHttpSnackBar('Цена с такой валютой за указанный период уже существует!');
        }
        else {
          this.prices.push(price);
          this.priceTable.renderRows();
        }
      }
    });
  }

  openAddAdvancePrice(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddPriceComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('advancePrice === undefined');
      }
      else{
        const advancePrice: TariffAdvancePrice = result;
        if (this.advancePrices.some(x =>
          x.period.periodUnit === advancePrice.period.periodUnit &&
          x.period.value === advancePrice.period.value &&
          x.price.currency === advancePrice.price.currency))
        {
          this.snackBarService.openErrorHttpSnackBar('Цена с такой валютой за указанный период уже существует!');
        }
        else {
          this.advancePrices.push(advancePrice);
          this.advancePriceTable.renderRows();
        }
      }
    });
  }

  openAddIncludedProduct(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddIncludedProductComponent, {data: this.includedProducts});
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('includedProduct === undefined');
      }
      else{
        const includedProduct = result;
        this.includedProducts.push(includedProduct);
        this.includedProductInTariffTable.renderRows();
      }
    });
  }

  openAddIncludedProductOption(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddIncludedProductOptionComponent, {data: this.includedProductOptions});
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('includedProductOption === undefined');
      }
      else{
        console.log('result: ', result);
        const includedProductOption = result;
        this.includedProductOptions.push(includedProductOption);
        this.includedProductOptionInTariffTable.renderRows();
      }
    });
  }

  openAddContractKindBindings(): void {
    let dialogRef;
    dialogRef = this.dialog.open(AddContractKindBindingComponent, {data: this.contractKindBindings});
    dialogRef.afterClosed().subscribe(result => {
      if (result === undefined)
      {
        console.log('contractKindBinding === undefined');
      }
      else{
        const contractKindBinding = result;
        this.contractKindBindings.push(contractKindBinding);
        this.tariffToContractKindBindingTable.renderRows();
      }
    });
  }

  parserPeriodUnit(id: number): any {
    return PeriodUnit[id];
  }

  deleteTariffPrice(price: TariffPrice): void {
    const index = this.prices.indexOf(price, 0);
    if (index > -1) {
      this.prices.splice(index, 1);
    }
    this.priceTable.renderRows();
  }

  deleteAdvancePrice(advancePrice: TariffAdvancePrice): void {
    const index = this.advancePrices.indexOf(advancePrice, 0);
    if (index > -1) {
      this.advancePrices.splice(index, 1);
    }
    this.advancePriceTable.renderRows();
  }

  deleteIncludedProduct(includedProduct: IncludedProductInTariff): void {
    const index = this.includedProducts.indexOf(includedProduct, 0);
    if (index > -1) {
      this.includedProducts.splice(index, 1);
    }
    this.includedProductInTariffTable.renderRows();
  }

  deleteIncludedProductOption(includedProductOption: IncludedProductOptionInTariff): void {
    const index = this.includedProductOptions.indexOf(includedProductOption, 0);
    if (index > -1) {
      this.includedProductOptions.splice(index, 1);
    }
    this.includedProductOptionInTariffTable.renderRows();
  }

  deleteContractKindBinding(contractKindBinding: TariffToContractKindBinding): void {
    const index = this.contractKindBindings.indexOf(contractKindBinding, 0);
    if (index > -1) {
      this.contractKindBindings.splice(index, 1);
    }
    this.tariffToContractKindBindingTable.renderRows();
  }
}

enum PeriodUnit {
  Month = 0,
  QuarterOfTheYear = 1,
  HalfYear = 2,
  Year = 3
}
