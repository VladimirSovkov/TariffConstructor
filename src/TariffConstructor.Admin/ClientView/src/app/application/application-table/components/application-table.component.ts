import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {MatTable} from '@angular/material/table';
import {ApplicationSearchPattern} from '../../../shared/model/application/application-search-pattern.model';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../../shared/service/snack-bar.service';
import {SearchResult} from '../../../shared/search-result.model';
import {Application} from '../../../shared/model/application/application.model';
import {ApplicationApiService} from '../../../shared/service/application/application-api.service';

@Component({
  selector: 'app-application-list',
  templateUrl: './application-table.component.html',
  styleUrls: ['./application-table.component.css']
})
export class ApplicationTableComponent implements OnInit {
  @Input() public applicationInput: Application[];
  displayedColumns: string[] = ['publicId', 'name', 'action'];
  applications: Application[];
  searchPattern: ApplicationSearchPattern;
  filter = '';
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;
  constructor(private router: Router,
              private applicationService: ApplicationApiService,
              private http: HttpClient,
              private snackBarService: SnackBarService) {
    this.searchPattern = new ApplicationSearchPattern();
    this.pageEvent = new PageEvent();
    this.pageEvent.pageIndex = 0;
    this.pageEvent.pageSize = 5;
  }

  ngOnInit(): void {
    this.load();
    console.log('input application: ', this.applicationInput);
  }

  load(): void {
    this.searchPattern.onPage = this.pageEvent.pageSize;
    this.searchPattern.pageNumber = this.pageEvent.pageIndex + 1;
    this.searchPattern.searchString = this.filter;
    this.applicationService.search(this.searchPattern).subscribe((searchResult: SearchResult<Application>) => {
      this.applications = searchResult.items;
      this.pageEvent.length = searchResult.totalCount;
    }, error => {
      this.snackBarService.openErrorHttpSnackBar(error);
    });
  }

  applyFilter(event: Event): void  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filter = filterValue.trim().toLowerCase();
    this.load();
  }

  delete(application: Application): void{
    this.applicationService.delete(application.id)
      .subscribe(() => {
        const index = this.applications.indexOf(application, 0);
        if (index > -1) {
          this.applications.splice(index, 1);
        }
        this.table.renderRows();
        this.load();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
