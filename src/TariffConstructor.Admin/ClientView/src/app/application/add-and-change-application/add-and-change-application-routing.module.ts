import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {AddAndChangeApplicationComponent} from './components/add-and-change-application/add-and-change-application.component';

const routes: Routes = [
  {path: 'application/add', component: AddAndChangeApplicationComponent},
  {path: 'application/change/:id', component: AddAndChangeApplicationComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddAndChangeApplicationRoutingModule {}
