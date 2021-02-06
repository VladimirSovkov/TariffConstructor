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
import { AddAndChangeAvailableTariffForUpgradeComponent } from './add-and-change-available-tariff-for-upgrade/add-and-change-available-tariff-for-upgrade.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {TariffService} from '../shared/service/tariff/tariff.service';
import {MatSelectModule} from '@angular/material/select';
import {MatOptionModule} from '@angular/material/core';



@NgModule({
  declarations: [AvailableTariffForUpgradeTableComponent, AddAndChangeAvailableTariffForUpgradeComponent],
  imports: [
    CommonModule,
    AvailableTariffForUpgradeRoutingModule,
    MatSidenavModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule
  ],
  exports: [],
  providers: [AvailableTariffForUpgradeService]
})
export class AvailableTariffForUpgradeModule { }
