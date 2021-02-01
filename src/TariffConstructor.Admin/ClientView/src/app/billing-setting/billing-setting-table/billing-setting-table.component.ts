import {Component, OnInit, ViewChild} from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {BillingSettingPaginationPattern} from '../../shared/model/billing-setting/billing-setting/billing-setting-pagination-pattern.model';
import {BillingSetting} from '../../shared/model/billing-setting/billing-setting/billing-setting.model';
import {Router} from '@angular/router';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {BillingSettingApiServices} from '../../shared/service/billing-setting/billing-setting.service';
import {PaginationResult} from '../../shared/model/pagination-pattern/pagination-result.model';
import {MatTable} from '@angular/material/table';

@Component({
  selector: 'app-billing-setting-table',
  templateUrl: './billing-setting-table.component.html',
  styleUrls: ['./billing-setting-table.component.css']
})
export class BillingSettingTableComponent implements OnInit {
  displayedColumns: string[] = ['setting', 'action'];
  paginationPattern: BillingSettingPaginationPattern;
  billingSettings: BillingSetting[];
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;
  constructor(private router: Router,
              private billingSettingServices: BillingSettingApiServices,
              private snackBarService: SnackBarService) {
    this.paginationPattern = new  BillingSettingPaginationPattern();
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
    this.billingSettingServices.pagination(this.paginationPattern)
      .subscribe((paginationResult: PaginationResult<BillingSetting>) => {
        this.billingSettings = paginationResult.items;
        this.pageEvent.length = paginationResult.totalCount;
      });
  }

  delete(billingSeting: BillingSetting): void {
    this.billingSettingServices.delete(billingSeting.id)
      .subscribe( () => {
        const index = this.billingSettings.indexOf(billingSeting, 0);
        if (index > -1) {
          this.billingSettings.splice(index, 1);
        }
        this.table.renderRows();
      });
  }

}
