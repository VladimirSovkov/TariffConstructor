import {Component, OnInit, ViewChild} from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {MatTable} from '@angular/material/table';
import {TermsOfUseSearchPattern} from '../../shared/model/terms-of-use/terms-of-use-search-pattern.model';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {SearchResult} from '../../shared/search-result.model';
import {TermsOfUse} from '../../shared/model/terms-of-use/terms-of-use.model';
import {TermsOfUseApiService} from '../../shared/service/terms-of-use/terms-of-use-api.service';

@Component({
  selector: 'app-terms-of-use-table',
  templateUrl: './terms-of-use-table.component.html',
  styleUrls: ['./terms-of-use-table.component.css']
})
export class TermsOfUseTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'publicId', 'documentName', 'action'];
  searchPattern: TermsOfUseSearchPattern;
  termsOfUses: TermsOfUse[];
  filter = '';
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;
  constructor(private router: Router,
              private termsOfUseService: TermsOfUseApiService,
              private http: HttpClient,
              private snackBarService: SnackBarService) {
    this.searchPattern = new TermsOfUseSearchPattern();
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
    this.termsOfUseService.search(this.searchPattern).subscribe((searchResult: SearchResult<TermsOfUse>) => {
      this.termsOfUses = searchResult.items;
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

  delete(termsOfUse: TermsOfUse): void{
    this.termsOfUseService.delete(termsOfUse.id)
      .subscribe(() => {
        const index = this.termsOfUses.indexOf(termsOfUse, 0);
        if (index > -1) {
          this.termsOfUses.splice(index, 1);
        }
        this.table.renderRows();
      });
  }
}
