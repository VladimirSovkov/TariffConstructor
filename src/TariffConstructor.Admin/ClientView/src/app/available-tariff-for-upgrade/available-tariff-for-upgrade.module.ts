import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AvailableTariffForUpgradeTableComponent } from './available-tariff-for-upgrade-table/available-tariff-for-upgrade-table.component';
import {AvailableTariffForUpgradeRoutingModule} from './available-tariff-for-upgrade-routing.module';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {AvailableTariffForUpgradeService} from './services/available-tariff-for-upgrade.service';
import {MatButtonModule} from '@angular/material/button';



@NgModule({
  declarations: [AvailableTariffForUpgradeTableComponent],
  imports: [
    CommonModule,
    AvailableTariffForUpgradeRoutingModule,
    MatSidenavModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule
  ],
  exports: [],
  providers: [AvailableTariffForUpgradeService]
})
export class AvailableTariffForUpgradeModule { }
