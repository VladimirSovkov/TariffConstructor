import { Component, OnInit } from '@angular/core';
import { ProductOption } from '../../shared/model/ProductOption/product-option.model';
import {ProductOptionSearchPattern} from '../../shared/model/ProductOption/product-option-search-pattern.model';
import {PageEvent} from '@angular/material/paginator';
import {ProductOptionService} from '../../shared/service/product-option/product-option.service';
import {SearchResult} from '../../shared/search-result.model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-product-option-table',
  templateUrl: './product-option-table.component.html',
  styleUrls: ['./product-option-table.component.css']
})
export class ProductOptionTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'nomenclatureId', 'productId', 'isMultiple', 'accountingName'];
  filter = '';
  productOptions: ProductOption[];
  searchPattern: ProductOptionSearchPattern;
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  constructor(private productOptionService: ProductOptionService, private router: Router) {
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
    this.productOptionService.getData(this.searchPattern).subscribe((searchResult: SearchResult<ProductOption>) => {
      this.productOptions = searchResult.items;
      this.pageEvent.length = searchResult.totalCount;
    });
  }

  applyFilter(event: Event): void  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filter = filterValue.trim().toLowerCase();
    this.load();
  }

  goAdd(): void {
    this.router.navigate(['addProductOption']);
  }
}
