import {Component, OnInit, ViewChild} from '@angular/core';
import { ProductOption } from '../../shared/model/productOption/product-option.model';
import {ProductOptionSearchPattern} from '../../shared/model/productOption/product-option-search-pattern.model';
import {PageEvent} from '@angular/material/paginator';
import {ProductOptionService} from '../../shared/service/product-option/product-option.service';
import {SearchResult} from '../../shared/search-result.model';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {MatTable} from '@angular/material/table';

@Component({
  selector: 'app-product-option-table',
  templateUrl: './product-option-table.component.html',
  styleUrls: ['./product-option-table.component.css']
})
export class ProductOptionTableComponent implements OnInit {
  displayedColumns: string[] = ['name', 'publicId', 'nomenclatureId', 'productId', 'accountingName', 'action'];
  filter = '';
  productOptions: ProductOption[];
  searchPattern: ProductOptionSearchPattern;
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;
  constructor(private productOptionService: ProductOptionService,
              private router: Router,
              private http: HttpClient,
              private snackBarService: SnackBarService) {
    this.searchPattern = new ProductOptionSearchPattern();
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
    this.productOptionService.search(this.searchPattern).subscribe((searchResult: SearchResult<ProductOption>) => {
      this.productOptions = searchResult.items;
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

  delete(product: ProductOption): void {
    this.productOptionService.delete(product.id)
      .subscribe(() => {
        const index = this.productOptions.indexOf(product, 0);
        if (index > -1) {
          this.productOptions.splice(index, 1);
        }
        this.table.renderRows();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
