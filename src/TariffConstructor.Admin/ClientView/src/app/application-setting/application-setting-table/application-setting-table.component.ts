import {Component, OnInit, ViewChild} from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {ApplicationSetting} from '../../shared/model/application-setting/application-setting.model';
import {ApplicationSettingPaginationPattern} from '../../shared/model/application-setting/application-setting-pagination-pattern.model';
import {Router} from '@angular/router';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {ApplicationSettingApiServices} from '../../shared/service/application-setting/application-setting.services';
import {PaginationResult} from '../../shared/model/pagination-pattern/pagination-result.model';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {MatTable} from '@angular/material/table';

@Component({
  selector: 'app-application-setting-table',
  templateUrl: './application-setting-table.component.html',
  styleUrls: ['./application-setting-table.component.css']
})
export class ApplicationSettingTableComponent implements OnInit {
  displayedColumns: string[] = ['application', 'setting', 'defaultValue', 'action'];
  applicationSettings: ApplicationSetting[];
  paginationPattern: ApplicationSettingPaginationPattern;
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;
  constructor(private router: Router,
              private http: HttpClient,
              private applicationSettingService: ApplicationSettingApiServices,
              private snackBarService: SnackBarService) {
    this.paginationPattern = new ApplicationSettingPaginationPattern();
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
    this.applicationSettingService.pagination(this.paginationPattern)
      .subscribe((paginationResult: PaginationResult<ApplicationSetting>) => {
        this.applicationSettings = paginationResult.items;
        this.pageEvent.length = paginationResult.totalCount;
      }, error => {
         this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  delete(applicationSetting: ApplicationSetting): void {
    this.applicationSettingService.delete(applicationSetting.id)
      .subscribe( () => {
        const index = this.applicationSettings.indexOf(applicationSetting, 0);
        if (index > -1) {
          this.applicationSettings.splice(index, 1);
        }
        this.table.renderRows();
      }, error => {
          this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
