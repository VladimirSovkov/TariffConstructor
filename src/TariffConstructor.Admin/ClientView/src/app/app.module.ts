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
    AddChangeApplicationSettingComponent
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
    ApplicationSettingApiServices
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
