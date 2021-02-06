import {Component, OnInit, ViewChild} from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {MatTable} from '@angular/material/table';
import {Router} from '@angular/router';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {AvailableTariffForUpgradeService} from '../services/available-tariff-for-upgrade.service';
import {PaginationResult} from '../../shared/model/pagination-pattern/pagination-result.model';
import {AvailableTariffForUpgradePaginationPattern} from '../models/available-tariff-for-upgrade-pagination-pattern.model';
import {AvailableTariffForUpgrade} from '../models/available-tariff-for-upgrade.model';

@Component({
  selector: 'app-available-tariff-for-upgrade-table',
  templateUrl: './available-tariff-for-upgrade-table.component.html',
  styleUrls: ['./available-tariff-for-upgrade-table.component.css']
})
export class AvailableTariffForUpgradeTableComponent implements OnInit {
  availableTariffForUpgrade: AvailableTariffForUpgrade[];
  displayedColumns: string[] = ['fromTariff', 'toTariff'];
  paginationPattern: AvailableTariffForUpgradePaginationPattern;
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;

  constructor(private router: Router,
              private availableTariffForUpgradeService: AvailableTariffForUpgradeService,
              private snackBarService: SnackBarService) {
    this.paginationPattern = new AvailableTariffForUpgradePaginationPattern();
    this.pageEvent = new PageEvent();
    this.pageEvent.pageIndex = 0;
    this.pageEvent.pageSize = 5;
  }

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.paginationPattern.onPage = this.pageEvent.pageSize;
    this.paginationPattern.pageNumber = this.pageEvent.pageIndex + 1;
    this.availableTariffForUpgradeService.pagination(this.paginationPattern)
      .subscribe((paginationResult: PaginationResult<AvailableTariffForUpgrade>) => {
        this.availableTariffForUpgrade = paginationResult.items;
        this.pageEvent.length = paginationResult.totalCount;
        console.log(this.availableTariffForUpgrade);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  delete(availableTariffForUpgrade: AvailableTariffForUpgrade): void {
    this.availableTariffForUpgradeService.delete(availableTariffForUpgrade.id)
      .subscribe( () => {
        const index = this.availableTariffForUpgrade.indexOf(availableTariffForUpgrade, 0);
        if (index > -1) {
          this.availableTariffForUpgrade.splice(index, 1);
        }
        this.table.renderRows();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
