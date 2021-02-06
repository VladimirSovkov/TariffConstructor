import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AvailableTariffForUpgradeTableComponent} from './available-tariff-for-upgrade-table/available-tariff-for-upgrade-table.component';
import {AddAndChangeAvailableTariffForUpgradeComponent} from './add-and-change-available-tariff-for-upgrade/add-and-change-available-tariff-for-upgrade.component';

const routes: Routes = [
  {
    path: 'availableTariffForUpgrade',
    component: AvailableTariffForUpgradeTableComponent
  },
  {
    path: 'availableTariffForUpgrade/add',
    component: AddAndChangeAvailableTariffForUpgradeComponent
  },
  {
    path: 'availableTariffForUpgrade/change/:id',
    component: AddAndChangeAvailableTariffForUpgradeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AvailableTariffForUpgradeRoutingModule {}
