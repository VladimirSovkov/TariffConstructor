import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AvailableTariffForUpgradeTableComponent} from './available-tariff-for-upgrade-table/available-tariff-for-upgrade-table.component';

const routes: Routes = [
  {
    path: 'availableTariffForUpgrade',
    component: AvailableTariffForUpgradeTableComponent,
    children: []
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AvailableTariffForUpgradeRoutingModule {}
