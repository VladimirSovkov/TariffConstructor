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
import { TariffTableComponent } from './Tariff/tariff-table/tariff-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModel} from './app-routing.module';
import { ProductTableComponent } from './Product/product-table/product-table.component';
import { ProductOptionTableComponent } from './ProductOption/product-option-table/product-option-table.component';
import { AddingTariffComponent } from './Tariff/adding-tariff/adding-tariff.component';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeleteMeComponent } from './delete-me/delete-me.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { TariffService } from './shared/service/tariff.service';
import { ProductService } from './shared/service/product/product.service';
import { ProductOptionService } from './shared/service/product-option/product-option.service';
import { AddProductComponent } from './Product/add-product/add-product.component';
import { AddProductOptionComponent } from './ProductOption/add-product-option/add-product-option.component';
import { ChangeTariffComponent } from './Tariff/change-tariff/change-tariff.component';
import { AddIncludedProductComponent } from './Tariff/add-included-product/add-included-product.component';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { AddPriceComponent } from './Tariff/add-price/add-price.component';
import { AddAdvancePriceComponent } from './Tariff/add-advance-price/add-advance-price.component';
import { AddIncludedProductOptionComponent } from './Tariff/add-included-product-option/add-included-product-option.component';
import { AddContractKindBindingComponent } from './Tariff/add-contract-kind-binding/add-contract-kind-binding.component';
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

@NgModule({
  declarations: [
      AppComponent,
    NavMenuComponent,
    TariffTableComponent,
    ProductTableComponent,
    ProductOptionTableComponent,
    AddingTariffComponent,
    DeleteMeComponent,
    AddProductComponent,
    AddProductOptionComponent,
    ChangeTariffComponent,
    AddIncludedProductComponent,
    AddPriceComponent,
    AddAdvancePriceComponent,
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
    TermsOfUseTableComponent
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
    MatExpansionModule
  ],
  exports: [
  ],
  providers: [TariffService,
    ProductService,
    ProductOptionService,
    SettingApiServices,
    ApiService,
    ApplicationSettingApiServices,
    BillingSettingApiServices,
    SettingsPresetApiServices,
    TermsOfUseApiService,
    ApplicationApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
