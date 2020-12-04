import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TariffTableComponent} from './Tariff/tariff-table/tariff-table.component';
import {ProductTableComponent} from './Product/product-table/product-table.component';
import {ProductOptionTableComponent} from './ProductOption/product-option-table/product-option-table.component';
import {AddingTariffComponent} from './Tariff/adding-tariff/adding-tariff.component';
import { AddProductComponent } from './Product/add-product/add-product.component';
import {AddProductOptionComponent} from './ProductOption/add-product-option/add-product-option.component';

// http://localhost:4200/tariff-> Home Component

const routes: Routes = [
  {path: 'tariff', component: TariffTableComponent},
  {path: 'addingTariff', component: AddingTariffComponent},
  {path: 'product', component: ProductTableComponent},
  {path: 'productOption', component: ProductOptionTableComponent},
  {path: 'addProduct', component: AddProductComponent},
  {path: 'addProductOption', component: AddProductOptionComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModel{

}

