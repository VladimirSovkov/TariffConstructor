import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {ApplicationTableComponent} from './components/application-table.component';
import {ApplicationTablePageComponent} from './pages/application-table-page/application-table-page.component';

const routes: Routes = [
  {path: 'application', component: ApplicationTablePageComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicationTableRoutingModule {}
