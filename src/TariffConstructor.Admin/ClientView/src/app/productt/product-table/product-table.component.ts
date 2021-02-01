import {Component, OnInit, ViewChild} from '@angular/core';
import { Product } from '../../shared/model/product/product.model';
import { ProductSearchPattern } from '../../shared/model/product/product-search-pattern.model';
import {PageEvent} from '@angular/material/paginator';
import {ProductService} from '../../shared/service/product/product.service';
import {SearchResult} from '../../shared/search-result.model';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {MatTable} from '@angular/material/table';

@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.css']
})
export class ProductTableComponent implements OnInit {
  displayedColumns: string[] = ['publicId', 'name', 'nomenclatureId', 'shortName', 'action'];
  products: Product[];
  filter = '';
  searchPattern: ProductSearchPattern;
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;
  constructor(private router: Router, private productService: ProductService, private http: HttpClient, private snackBarService: SnackBarService) {
    this.searchPattern = new ProductSearchPattern();
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
    this.productService.search(this.searchPattern).subscribe((searchResult: SearchResult<Product>) => {
      this.products = searchResult.items;
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

  delete(product: Product): void{
    this.productService.delete(product.id)
      .subscribe(() => {
        const index = this.products.indexOf(product, 0);
        if (index > -1) {
          this.products.splice(index, 1);
        }
        this.table.renderRows();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
