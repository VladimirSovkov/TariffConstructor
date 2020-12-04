import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchResult } from '../../search-result.model';
import { Product } from '../../model/Product/product.model';
import { ProductSearchPattern } from '../../model/Product/product-search-pattern.model';

@Injectable()
export class ProductService{
  apiUrl = 'здесь мой апи';
  constructor(private http: HttpClient) {
  }

  getData(searchPattern: ProductSearchPattern): Observable<SearchResult<Product>>{
    const params = new HttpParams()
      .set('pageNumber', searchPattern.pageNumber.toString())
      .set('onPage', searchPattern.onPage.toString())
      .set('searchString', searchPattern.searchString.toString());
    return this.http.get<SearchResult<Product>>('http://localhost:4401/test/product', {params});
  }
}
