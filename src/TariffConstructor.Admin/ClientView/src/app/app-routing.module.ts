import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TariffTableComponent } from './Tariff/tariff-table/tariff-table.component';
import { ProductTableComponent } from './Product/product-table/product-table.component';
import { ProductOptionTableComponent } from './ProductOption/product-option-table/product-option-table.component';
import { AddingTariffComponent } from './Tariff/adding-tariff/adding-tariff.component';
import { AddProductComponent } from './Product/add-product/add-product.component';
import { AddProductOptionComponent } from './ProductOption/add-product-option/add-product-option.component';
import { ChangeTariffComponent } from './Tariff/change-tariff/change-tariff.component';
import {SettingTableComponent} from './setting/setting-table/setting-table.component';
import {AddChangeSettingComponent} from './setting/add-change-setting/add-change-setting.component';
import {ApplicationSettingTableComponent} from './application-setting/application-setting-table/application-setting-table.component';
import {AddChangeApplicationSettingComponent} from './application-setting/add-change-application-setting/add-change-application-setting.component';
import {SettingPresetTableComponent} from './setting-preset/setting-preset-table/setting-preset-table.component';
import {BillingSettingTableComponent} from './billing-setting/billing-setting-table/billing-setting-table.component';
import {AddAndChangeSettingsPresetComponent} from './setting-preset/add-and-change-settings-preset/add-and-change-settings-preset.component';
import {AddAndChangeBillingSettingComponent} from './billing-setting/add-and-change-billing-setting/add-and-change-billing-setting.component';
import {ApplicationTableComponent} from './application/application-table/application-table.component';
import {AddAndChangeApplicationComponent} from './application/add-and-change-application/add-and-change-application.component';
import {TermsOfUseTableComponent} from './terms-of-use/terms-of-use-table/terms-of-use-table.component';
import {AddAndChangeTermsOfUseComponent} from './terms-of-use/add-and-change-terms-of-use/add-and-change-terms-of-use.component';
import {CurrencyTableComponent} from './currency/currency-table/currency-table.component';
import {AddAndChangeCurrencyComponent} from './currency/add-and-change-currency/add-and-change-currency.component';

// http://localhost:4200/tariff-> Home Component

const routes: Routes = [
  {path: 'tariff', component: TariffTableComponent},
  {path: 'addingTariff', component: AddingTariffComponent},
  {path: 'product', component: ProductTableComponent},
  {path: 'productOption', component: ProductOptionTableComponent},
  {path: 'product/add', component: AddProductComponent},
  {path: 'product/change/:id',  component: AddProductComponent },
  {path: 'productOption/change/:id', component: AddProductOptionComponent},
  {path: 'productOption/change', component: AddProductOptionComponent},
  {path: 'changeTariff/:id', component: AddingTariffComponent},
  {path: 'changeTariff', component: AddingTariffComponent},

  {path: 'setting', component: SettingTableComponent},
  {path: 'setting/add', component: AddChangeSettingComponent},
  {path: 'setting/change/:id', component: AddChangeSettingComponent},

  {path: 'applicationSetting', component: ApplicationSettingTableComponent},
  {path: 'applicationSetting/add', component: AddChangeApplicationSettingComponent},
  {path: 'applicationSetting/change/:id', component: AddChangeApplicationSettingComponent},

  {path: 'settingsPreset', component: SettingPresetTableComponent},
  {path: 'settingsPreset/add', component: AddAndChangeSettingsPresetComponent},
  {path: 'settingsPreset/change/:id', component: AddAndChangeSettingsPresetComponent},

  {path: 'billingSetting', component: BillingSettingTableComponent},
  {path: 'billingSetting/add', component: AddAndChangeBillingSettingComponent},
  {path: 'billingSetting/change/:id', component: AddAndChangeBillingSettingComponent},

  {path: 'application', component: ApplicationTableComponent},
  {path: 'application/add', component: AddAndChangeApplicationComponent},
  {path: 'application/change/:id', component: AddAndChangeApplicationComponent},

  {path: 'termsOfUse', component: TermsOfUseTableComponent},
  {path: 'termsOfUse/add', component: AddAndChangeTermsOfUseComponent},
  {path: 'termsOfUse/change/:id', component: AddAndChangeTermsOfUseComponent},

  {path: 'currency', component: CurrencyTableComponent},
  {path: 'currency/add', component: AddAndChangeCurrencyComponent},
  {path: 'currency/change/:id', component: AddAndChangeCurrencyComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModel{

}

