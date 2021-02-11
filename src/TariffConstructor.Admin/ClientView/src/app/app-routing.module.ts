import { NgModule } from '@angular/core';
import {PreloadAllModules, RouterModule, Routes} from '@angular/router';
import { TariffTableComponent } from './tariff/tariff-table/tariff-table.component';
import { ProductTableComponent } from './product/product-table/product-table.component';
import { ProductOptionTableComponent } from './product-option/product-option-table/product-option-table.component';
import { AddAndChangeTariffComponent } from './tariff/add-and-change-tariff/add-and-change-tariff.component';
import { AddProductComponent } from './product/add-product/add-product.component';
import { AddProductOptionComponent } from './product-option/add-product-option/add-product-option.component';
import {SettingTableComponent} from './setting/setting-table/setting-table.component';
import {AddChangeSettingComponent} from './setting/add-change-setting/add-change-setting.component';
import {ApplicationSettingTableComponent} from './application-setting/application-setting-table/application-setting-table.component';
import {AddChangeApplicationSettingComponent} from './application-setting/add-change-application-setting/add-change-application-setting.component';
import {SettingPresetTableComponent} from './setting-preset/setting-preset-table/setting-preset-table.component';
import {BillingSettingTableComponent} from './billing-setting/billing-setting-table/billing-setting-table.component';
import {AddAndChangeSettingsPresetComponent} from './setting-preset/add-and-change-settings-preset/add-and-change-settings-preset.component';
import {AddAndChangeBillingSettingComponent} from './billing-setting/add-and-change-billing-setting/add-and-change-billing-setting.component';
import {ApplicationTableComponent} from './application/application-table/components/application-table.component';
import {AddAndChangeApplicationComponent} from './application/add-and-change-application/components/add-and-change-application/add-and-change-application.component';
import {TermsOfUseTableComponent} from './terms-of-use/terms-of-use-table/terms-of-use-table.component';
import {AddAndChangeTermsOfUseComponent} from './terms-of-use/add-and-change-terms-of-use/add-and-change-terms-of-use.component';
import {CurrencyTableComponent} from './currency/currency-table/currency-table.component';
import {AddAndChangeCurrencyComponent} from './currency/add-and-change-currency/add-and-change-currency.component';
import {AddAndChangeProductOptionTariffComponent} from './product-option-tariff/add-and-change-product-option-tariff/add-and-change-product-option-tariff.component';
import {ProductOptionTariffTableComponent} from './product-option-tariff/product-option-tariff-table/product-option-tariff-table.component';
import {AddAndChangeContractKindComponent} from './contract-kind/add-and-change-contract-kind/add-and-change-contract-kind.component';
import {ContractKindTableComponent} from './contract-kind/contract-kind-table/contract-kind-table.component';

const routes: Routes = [
  {path: 'tariff', component: TariffTableComponent},
  {path: 'tariff/add', component: AddAndChangeTariffComponent},
  {path: 'tariff/change/:id', component: AddAndChangeTariffComponent},

  {path: 'product', component: ProductTableComponent},
  {path: 'product/add', component: AddProductComponent},
  {path: 'product/change/:id',  component: AddProductComponent },

  {path: 'product-option', component: ProductOptionTableComponent},
  {path: 'product-option/add', component: AddProductOptionComponent},
  {path: 'product-option/change/:id', component: AddProductOptionComponent},

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

  {path: 'termsOfUse', component: TermsOfUseTableComponent},
  {path: 'termsOfUse/add', component: AddAndChangeTermsOfUseComponent},
  {path: 'termsOfUse/change/:id', component: AddAndChangeTermsOfUseComponent},

  {path: 'currency', component: CurrencyTableComponent},
  {path: 'currency/add', component: AddAndChangeCurrencyComponent},
  {path: 'currency/change/:id', component: AddAndChangeCurrencyComponent},

  {path: 'productOptionTariff', component: ProductOptionTariffTableComponent},
  {path: 'productOptionTariff/add', component: AddAndChangeProductOptionTariffComponent},
  {path: 'productOptionTariff/change/:id', component: AddAndChangeProductOptionTariffComponent},

  {path: 'contractKind', component: ContractKindTableComponent},
  {path: 'contractKind/add', component: AddAndChangeContractKindComponent},
  {path: 'contractKind/change/:id', component: AddAndChangeContractKindComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {preloadingStrategy: PreloadAllModules})],
  exports: [RouterModule]
})

export class AppRoutingModel{

}
