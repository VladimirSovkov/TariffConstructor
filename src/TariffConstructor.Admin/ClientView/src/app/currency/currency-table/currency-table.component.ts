import {Component, OnInit, ViewChild} from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {SearchResult} from '../../shared/search-result.model';
import {CurrencySearchPattern} from '../../shared/model/currency/currency-search-pattern.model';
import {Currency} from '../../shared/model/currency/currency.model';
import {CurrencyService} from '../../shared/service/currency/currency.service';
import {MatTable} from '@angular/material/table';

@Component({
  selector: 'app-currency-table',
  templateUrl: './currency-table.component.html',
  styleUrls: ['./currency-table.component.css']
})
export class CurrencyTableComponent implements OnInit {
  displayedColumns: string[] = ['code', 'name', 'action'];
  searchPattern: CurrencySearchPattern;
  currencies: Currency[];
  filter = '';
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
    @ViewChild(MatTable) table: MatTable<any>;
  constructor(private router: Router,
              private currencyService: CurrencyService,
              private http: HttpClient,
              private snackBarService: SnackBarService) {
    this.searchPattern = new CurrencySearchPattern();
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
    this.currencyService.search(this.searchPattern).subscribe((searchResult: SearchResult<Currency>) => {
      this.currencies = searchResult.items;
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

  delete(currency: Currency): void{
    this.currencyService.delete(currency.id)
      .subscribe(() => {
        const index = this.currencies.indexOf(currency, 0);
        if (index > -1) {
          this.currencies.splice(index, 1);
        }
        this.table.renderRows();
      });
  }

}
