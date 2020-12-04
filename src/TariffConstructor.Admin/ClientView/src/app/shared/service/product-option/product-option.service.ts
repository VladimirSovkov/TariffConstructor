import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchResult } from '../../search-result.model';
import { ProductOption } from '../../model/ProductOption/product-option.model';
import { ProductOptionSearchPattern } from '../../model/ProductOption/product-option-search-pattern.model';

@Injectable()
export class ProductOptionService{
  apiUrl = 'здесь мой апи';
  constructor(private http: HttpClient) {
  }

  getData(searchPattern: ProductOptionSearchPattern): Observable<SearchResult<ProductOption>>{
    const params = new HttpParams()
      .set('pageNumber', searchPattern.pageNumber.toString())
      .set('onPage', searchPattern.onPage.toString())
      .set('searchString', searchPattern.searchString.toString());
    return this.http.get<SearchResult<ProductOption>>('http://localhost:4401/test/productOption', {params});
  }
}
