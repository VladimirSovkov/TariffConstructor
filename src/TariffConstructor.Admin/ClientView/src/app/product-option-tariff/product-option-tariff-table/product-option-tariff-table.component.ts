import {Component, OnInit, ViewChild} from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {MatTable} from '@angular/material/table';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {SearchResult} from '../../shared/search-result.model';
import {ProductOptionTariff} from '../../shared/model/product-option-tariff/product-option-tariff.model';
import {ProductOptionTariffSearchPattern} from '../../shared/model/product-option-tariff/product-option-tariff-search-pattern.model';
import {ProductOptionTariffService} from '../../shared/service/product-option-tariff/product-option-tariff.service';

@Component({
  selector: 'app-product-option-tariff-table',
  templateUrl: './product-option-tariff-table.component.html',
  styleUrls: ['./product-option-tariff-table.component.css']
})
export class ProductOptionTariffTableComponent implements OnInit {
  displayedColumns: string[] = ['name', 'productOption', 'action'];
  searchPattern: ProductOptionTariffSearchPattern;
  productOptionTariffs: ProductOptionTariff[];
  filter = '';
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;
  constructor(private router: Router,
              private productOptionTariffService: ProductOptionTariffService,
              private http: HttpClient,
              private snackBarService: SnackBarService) {
    this.searchPattern = new ProductOptionTariffSearchPattern();
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
    this.productOptionTariffService.search(this.searchPattern).subscribe((searchResult: SearchResult<ProductOptionTariff>) => {
      this.productOptionTariffs = searchResult.items;
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

  delete(productOptionTariff: ProductOptionTariff): void{
    this.productOptionTariffService.delete(productOptionTariff.id)
      .subscribe(() => {
        const index = this.productOptionTariffs.indexOf(productOptionTariff, 0);
        if (index > -1) {
          this.productOptionTariffs.splice(index, 1);
        }
        this.table.renderRows();
        this.load();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
