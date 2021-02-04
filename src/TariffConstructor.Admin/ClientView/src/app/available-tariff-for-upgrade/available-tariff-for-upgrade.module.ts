import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AvailableTariffForUpgradeTableComponent } from './available-tariff-for-upgrade-table/available-tariff-for-upgrade-table.component';
import {AvailableTariffForUpgradeRoutingModule} from './available-tariff-for-upgrade-routing.module';



@NgModule({
  declarations: [AvailableTariffForUpgradeTableComponent],
  imports: [
    CommonModule,
    AvailableTariffForUpgradeRoutingModule,
  ],
  exports: []
})
export class AvailableTariffForUpgradeModule { }
