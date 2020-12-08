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
import {AppRoutingModel} from './app-routing.module';
import { ProductTableComponent } from './Product/product-table/product-table.component';
import { ProductOptionTableComponent } from './ProductOption/product-option-table/product-option-table.component';
import { AddingTariffComponent } from './Tariff/adding-tariff/adding-tariff.component';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeleteMeComponent } from './delete-me/delete-me.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import {MatFormFieldModule} from '@angular/material/form-field';
import { TariffService } from './shared/service/tariff.service';
import { ProductService } from './shared/service/product/product.service';
import { ProductOptionService } from './shared/service/product-option/product-option.service';
import { AddProductComponent } from './Product/add-product/add-product.component';
import { AddProductOptionComponent } from './ProductOption/add-product-option/add-product-option.component';
import { ChangeTariffComponent } from './Tariff/change-tariff/change-tariff.component';


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
    ChangeTariffComponent
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
    ReactiveFormsModule,
    FormsModule,
  ],
  exports: [
    NavMenuComponent,
    AddingTariffComponent
  ],
  providers: [TariffService,
    ProductService,
    ProductOptionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
