import { Component, OnInit } from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {BillingSettingPaginationPattern} from '../../shared/model/billing-setting/billing-setting/billing-setting-pagination-pattern.model';
import {BillingSetting} from '../../shared/model/billing-setting/billing-setting/billing-setting.model';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {BillingSettingApiServices} from '../../shared/service/billing-setting/billing-setting.service';
import {PaginationResult} from '../../shared/model/pagination-pattern/pagination-result.model';

@Component({
  selector: 'app-billing-setting-table',
  templateUrl: './billing-setting-table.component.html',
  styleUrls: ['./billing-setting-table.component.css']
})
export class BillingSettingTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'settingId', 'action'];
  paginationPattern: BillingSettingPaginationPattern;
  billingSettings: BillingSetting[];
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  constructor(private router: Router,
              private settingService: BillingSettingApiServices,
              private http: HttpClient,
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
    this.settingService.pagination(this.paginationPattern)
      .subscribe((paginationResult: PaginationResult<BillingSetting>) => {
        this.billingSettings = paginationResult.items;
        this.pageEvent.length = paginationResult.totalCount;
      });
  }

  delete(id: number): void {
    this.settingService.delete(id)
      .subscribe( () => {
        console.log('Удалил');
      });
  }

}
