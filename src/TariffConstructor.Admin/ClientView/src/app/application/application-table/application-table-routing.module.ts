import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {ApplicationTableComponent} from './components/application-table.component';

const routes: Routes = [
  {path: 'application', component: ApplicationTableComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicationTableRoutingModule {}
