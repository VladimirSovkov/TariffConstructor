import { Component, OnInit, ViewChild } from '@angular/core';
import {MatTable} from '@angular/material/table';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {PageEvent} from '@angular/material/paginator';
import {SettingSearchPattern} from '../../shared/model/setting/setting-search-pattern.model';
import {Setting} from '../../shared/model/setting/setting.model';
import {SearchResult} from '../../shared/search-result.model';
import {SettingApiServices} from '../../shared/service/setting/setting-api.services';
import {MatSnackBar} from '@angular/material/snack-bar';
import {SnackBarService} from '../../shared/service/snack-bar.service';

@Component({
  selector: 'app-setting-table',
  templateUrl: './setting-table.component.html',
  styleUrls: ['./setting-table.component.css']
})

export class SettingTableComponent implements OnInit {
  displayedColumns: string[] = ['name', 'code', 'type', 'action'];
  settings: Setting[];
  searchPattern: SettingSearchPattern;
  filter = '';
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;

  constructor(private router: Router,
              private settingService: SettingApiServices,
              private http: HttpClient,
              private snackBarService: SnackBarService) {
    this.searchPattern = new SettingSearchPattern();
    this.pageEvent = new PageEvent();
    this.pageEvent.pageIndex = 0;
    this.pageEvent.pageSize = 5;
  }

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.searchPattern.onPage = this.pageEvent.pageSize;
    this.searchPattern.pageNumber = this.pageEvent.pageIndex + 1;
    this.searchPattern.searchString = this.filter;
    this.settingService.search(this.searchPattern).subscribe((searchResult: SearchResult<Setting>) => {
      this.settings = searchResult.items;
      this.pageEvent.length = searchResult.totalCount;
    }, error => {

    });
  }

  applyFilter(event: Event): void  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filter = filterValue.trim().toLowerCase();
    this.load();
  }

  delete(setting: Setting): void{
    this.settingService.delete(setting.id)
      .subscribe(() => {
        const index = this.settings.indexOf(setting, 0);
        if (index > -1) {
          this.settings.splice(index, 1);
        }
        this.table.renderRows();
      });
  }

  parserSettingType(id: number): any {
    return SettingType[id];
  }
}

enum SettingType {
  Unknown = 0,
  AccumulativeInteger = 1,
  AccumulativeBoolean = 2,
  ExclusiveInteger = 3,
  ExclusiveBoolean = 4,
  AccumulativeMultiEnum = 5,
  AccumulativeMoney = 6,
  ExclusiveEnum = 7,
  ExclusiveString = 8
}
