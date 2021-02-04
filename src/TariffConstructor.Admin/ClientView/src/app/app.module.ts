import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { TariffTableComponent } from './tariff/tariff-table/tariff-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModel} from './app-routing.module';
import { ProductTableComponent } from './product/product-table/product-table.component';
import { ProductOptionTableComponent } from './product-option/product-option-table/product-option-table.component';
import { AddAndChangeTariffComponent } from './tariff/add-and-change-tariff/add-and-change-tariff.component';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { ProductService } from './shared/service/product/product.service';
import { ProductOptionService } from './shared/service/product-option/product-option.service';
import { AddProductComponent } from './product/add-product/add-product.component';
import { AddProductOptionComponent } from './product-option/add-product-option/add-product-option.component';
import { AddIncludedProductComponent } from './tariff/add-included-product/add-included-product.component';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { AddPriceComponent } from './tariff/add-price/add-price.component';
import { AddIncludedProductOptionComponent } from './tariff/add-included-product-option/add-included-product-option.component';
import { AddContractKindBindingComponent } from './tariff/add-contract-kind-binding/add-contract-kind-binding.component';
import { SettingTableComponent } from './setting/setting-table/setting-table.component';
import {SettingApiServices} from './shared/service/setting/setting-api.services';
import {ApiService} from './shared/service/api.service';
import { AddChangeSettingComponent } from './setting/add-change-setting/add-change-setting.component';
import { ApplicationSettingTableComponent } from './application-setting/application-setting-table/application-setting-table.component';
import { AddChangeApplicationSettingComponent } from './application-setting/add-change-application-setting/add-change-application-setting.component';
import {ApplicationSettingApiServices} from './shared/service/application-setting/application-setting.services';
import { SettingPresetTableComponent } from './setting-preset/setting-preset-table/setting-preset-table.component';
import { AddAndChangeSettingsPresetComponent } from './setting-preset/add-and-change-settings-preset/add-and-change-settings-preset.component';
import { BillingSettingTableComponent } from './billing-setting/billing-setting-table/billing-setting-table.component';
import { AddAndChangeBillingSettingComponent } from './billing-setting/add-and-change-billing-setting/add-and-change-billing-setting.component';
import {BillingSettingApiServices} from './shared/service/billing-setting/billing-setting.service';
import {SettingsPresetApiServices} from './shared/service/setting/settings-preset.service';
import { AddBillingSettingPresetComponent } from './setting-preset/add-and-change-settings-preset/add-billing-setting-preset/add-billing-setting-preset.component';
import { AddApplicationSettingPresetsComponent } from './setting-preset/add-and-change-settings-preset/add-application-setting-presets/add-application-setting-presets.component';
import { AddAndChangeTermsOfUseComponent } from './terms-of-use/add-and-change-terms-of-use/add-and-change-terms-of-use.component';
import { ApplicationTableComponent } from './application/application-table/application-table.component';
import { AddAndChangeApplicationComponent } from './application/add-and-change-application/add-and-change-application.component';
import {TermsOfUseTableComponent} from './terms-of-use/terms-of-use-table/terms-of-use-table.component';
import {TermsOfUseApiService} from './shared/service/terms-of-use/terms-of-use-api.service';
import {ApplicationApiService} from './shared/service/application/application-api.service';
import { CurrencyTableComponent } from './currency/currency-table/currency-table.component';
import { AddAndChangeCurrencyComponent } from './currency/add-and-change-currency/add-and-change-currency.component';
import {CurrencyService} from './shared/service/currency/currency.service';
import { ProductOptionTariffTableComponent } from './product-option-tariff/product-option-tariff-table/product-option-tariff-table.component';
import { AddAndChangeProductOptionTariffComponent } from './product-option-tariff/add-and-change-product-option-tariff/add-and-change-product-option-tariff.component';
import {ProductOptionTariffService} from './shared/service/product-option-tariff/product-option-tariff.service';
import { AddProductOptionTariffPriceComponent } from './product-option-tariff/add-and-change-product-option-tariff/add-product-option-tariff-price/add-product-option-tariff-price.component';
import {ProductOption} from './shared/model/productOption/product-option.model';
import {TariffService} from './shared/service/tariff/tariff.service';
import {ContractKindService} from './shared/service/contract-kind/contract-kind.service';
import { AddAndChangeContractKindComponent } from './contract-kind/add-and-change-contract-kind/add-and-change-contract-kind.component';
import { ContractKindTableComponent } from './contract-kind/contract-kind-table/contract-kind-table.component';
import { AddApplicationSettingComponent } from './setting-preset/add-and-change-settings-preset/add-application-setting-presets/add-application-setting/add-application-setting.component';
import { AddBillingSettingComponent } from './setting-preset/add-and-change-settings-preset/add-billing-setting-preset/add-billing-setting/add-billing-setting.component';
import { AddAdvancedPriceComponent } from './tariff/add-advanced-price/add-advanced-price.component';
import {AvailableTariffForUpgradeRoutingModule} from './available-tariff-for-upgrade/available-tariff-for-upgrade-routing.module';
import {AvailableTariffForUpgradeModule} from './available-tariff-for-upgrade/available-tariff-for-upgrade.module';

@NgModule({
  declarations: [
      AppComponent,
    NavMenuComponent,
    TariffTableComponent,
    ProductTableComponent,
    ProductOptionTableComponent,
    AddAndChangeTariffComponent,
    AddProductComponent,
    AddProductOptionComponent,
    AddIncludedProductComponent,
    AddPriceComponent,
    AddIncludedProductOptionComponent,
    AddContractKindBindingComponent,
    SettingTableComponent,
    AddChangeSettingComponent,
    ApplicationSettingTableComponent,
    AddChangeApplicationSettingComponent,
    SettingPresetTableComponent,
    AddAndChangeSettingsPresetComponent,
    BillingSettingTableComponent,
    AddAndChangeBillingSettingComponent,
    AddBillingSettingPresetComponent,
    AddApplicationSettingPresetsComponent,
    AddAndChangeTermsOfUseComponent,
    ApplicationTableComponent,
    AddAndChangeApplicationComponent,
    TermsOfUseTableComponent,
    CurrencyTableComponent,
    AddAndChangeCurrencyComponent,
    ProductOptionTariffTableComponent,
    AddAndChangeProductOptionTariffComponent,
    AddProductOptionTariffPriceComponent,
    AddAndChangeContractKindComponent,
    ContractKindTableComponent,
    AddApplicationSettingComponent,
    AddBillingSettingComponent,
    AddAdvancedPriceComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    LayoutModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatCheckboxModule,
    MatFormFieldModule,
    HttpClientModule,
    AppRoutingModel,
    MatInputModule,
    MatSelectModule,
    MatRadioModule,
    MatDialogModule,
    MatSnackBarModule,
    ReactiveFormsModule,
    FormsModule,
    MatExpansionModule,
    AvailableTariffForUpgradeModule
  ],
  exports: [
  ],
  providers: [
    ProductService,
    ProductOptionService,
    SettingApiServices,
    ApiService,
    ApplicationSettingApiServices,
    BillingSettingApiServices,
    SettingsPresetApiServices,
    TermsOfUseApiService,
    ApplicationApiService,
    CurrencyService,
    ProductOptionTariffService,
    ProductOptionService,
    TariffService,
    ContractKindService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
