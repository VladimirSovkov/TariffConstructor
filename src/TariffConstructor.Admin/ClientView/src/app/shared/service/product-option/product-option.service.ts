import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchResult } from '../../search-result.model';
import { ProductOption } from '../../model/ProductOption/product-option.model';
import { ProductOptionSearchPattern } from '../../model/ProductOption/product-option-search-pattern.model';
import {ApiService} from '../api.service';

@Injectable()
export class ProductOptionService{
  apiUrl = '/productOption';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: ProductOptionSearchPattern): Observable<SearchResult<ProductOption>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<ProductOption>{
    return this.apiService.get(this.apiUrl + '/get', new HttpParams().set('id', id.toString()));
  }

  add(productOption: ProductOption): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', productOption);
  }

  update(productOption: ProductOption): Observable<any> {
    return this.apiService.post(this.apiUrl + '/update', productOption);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/', new HttpParams().set('id', id.toString()));
  }

  getAll(): Observable<ProductOption[]> {
    return this.apiService.get(this.apiUrl + '/getAll');
  }

}
