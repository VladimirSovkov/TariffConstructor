import { Component, OnInit } from '@angular/core';
import { Product } from '../../shared/model/product/product.model';
import { ProductSearchPattern } from '../../shared/model/product/product-search-pattern.model';
import {PageEvent} from '@angular/material/paginator';
import {ProductService} from '../../shared/service/product/product.service';
import {SearchResult} from '../../shared/search-result.model';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.css']
})
export class ProductTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'nomenclatureId', 'shortName', 'action'];
  products: Product[];
  filter = '';
  searchPattern: ProductSearchPattern;
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  constructor(private router: Router, private productService: ProductService, private http: HttpClient) {
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
    this.productService.getData(this.searchPattern).subscribe((searchResult: SearchResult<Product>) =>{
      this.products = searchResult.items;
      this.pageEvent.length = searchResult.totalCount;
    });
  }

  applyFilter(event: Event): void  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filter = filterValue.trim().toLowerCase();
    this.load();
  }

  delete(id: number): void{
    this.http.delete('http://localhost:4401/product/delete?id=' + id )
      .subscribe(() => {
        this.load();
      });
  }
}
