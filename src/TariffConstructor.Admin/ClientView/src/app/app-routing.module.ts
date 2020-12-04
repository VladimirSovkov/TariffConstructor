import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TariffTableComponent} from './Tariff/tariff-table/tariff-table.component';
import {ProductTableComponent} from './Product/product-table/product-table.component';
import {ProductOptionTableComponent} from './ProductOption/product-option-table/product-option-table.component';
import {AddingTariffComponent} from './Tariff/adding-tariff/adding-tariff.component';
import { AppComponent } from './app.component';

// http://localhost:4200/tariff-> Home Component

const routes: Routes = [
  {path: 'tariff', component: TariffTableComponent},
  {path: 'addingTariff', component: AddingTariffComponent},
  {path: 'product', component: ProductTableComponent},
  {path: 'productOption', component: ProductOptionTableComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModel{

}

