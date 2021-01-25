import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {SimplifiedTariff} from '../../shared/model/simplified-tariff.model';
import { TariffSearchPattern } from '../../shared/tariff-search-pattern.model';
import {SearchResult} from '../../shared/search-result.model';
import { PageEvent } from '@angular/material/paginator';
import {TariffService} from '../../shared/service/tariff/tariff.service';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {Tariff} from '../../shared/model/tariff/tariff.model';

@Component({
  selector: 'app-tariff-table',
  templateUrl: './tariff-table.component.html',
  styleUrls: ['./tariff-table.component.css']
})

export class TariffTableComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'paymentType', 'action'];
  tariffs: Tariff[];
  filter = '';
  searchPattern: TariffSearchPattern;
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  constructor(private http: HttpClient,
              private router: Router,
              private tariffService: TariffService,
              private snackBarService: SnackBarService)
  {
    this.searchPattern = new TariffSearchPattern();
    this.pageEvent = new PageEvent();
    this.pageEvent.pageIndex = 0;
    this.pageEvent.pageSize = 5;
  }

   ngOnInit(): void {
     this.load();
   }

  load(): void{
    this.searchPattern.onPage = this.pageEvent.pageSize;
    this.searchPattern.pageNumber = this.pageEvent.pageIndex + 1;
    this.searchPattern.searchString = this.filter;
    this.tariffService.search(this.searchPattern)
      .subscribe( (searchResult: SearchResult<Tariff>) => {
        this.tariffs = searchResult.items;
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
}
