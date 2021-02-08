import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchResult } from '../../search-result.model';
import { ProductOption } from '../../model/productOption/product-option.model';
import { ProductOptionSearchPattern } from '../../model/productOption/product-option-search-pattern.model';
import {ApiService} from '../api.service';

@Injectable()
export class ProductOptionService{
  apiUrl = '/productOptions';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: ProductOptionSearchPattern): Observable<SearchResult<ProductOption>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<ProductOption>{
    return this.apiService.get(this.apiUrl + '/' + id);
  }

  add(productOption: ProductOption): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', productOption);
  }

  update(productOption: ProductOption): Observable<any> {
    return this.apiService.post(this.apiUrl + '/', productOption);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/' + id);
  }

  getAll(): Observable<ProductOption[]> {
    return this.apiService.get(this.apiUrl + '/');
  }

}
