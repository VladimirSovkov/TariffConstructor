import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchResult } from '../../search-result.model';
import {ApiService} from '../api.service';
import {ProductOptionTariffSearchPattern} from '../../model/product-option-tariff/product-option-tariff-search-pattern.model';
import {ProductOptionTariff} from '../../model/product-option-tariff/product-option-tariff.model';

@Injectable()
export class ProductOptionTariffService{
  apiUrl = '/productOptionTariff';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: ProductOptionTariffSearchPattern): Observable<SearchResult<ProductOptionTariff>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<ProductOptionTariff>{
    return this.apiService.get(this.apiUrl + '/get', new HttpParams().set('id', id.toString()));
  }

  add(productOptionTariff: ProductOptionTariff): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', productOptionTariff);
  }

  update(productOptionTariff: ProductOptionTariff): Observable<any> {
    return this.apiService.post(this.apiUrl + '/update', productOptionTariff);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/', new HttpParams().set('id', id.toString()));
  }
}
