import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchResult } from '../../search-result.model';
import { Product } from '../../model/product/product.model';
import { ProductSearchPattern } from '../../model/product/product-search-pattern.model';
import {ApiService} from '../api.service';

@Injectable()
export class ProductService{
  apiUrl = '/product';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }
  search(searchPattern: ProductSearchPattern): Observable<SearchResult<Product>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<Product>{
    return this.apiService.get(this.apiUrl + '/get', new HttpParams().set('id', id.toString()));
  }

  add(product: Product): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', product);
  }

  update(product: Product): Observable<any> {
    return this.apiService.post(this.apiUrl + '/update', product);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/', new HttpParams().set('id', id.toString()));
  }

  getProducts(): Observable<Product[]> {
    return this.apiService.get(this.apiUrl + '/getProducts');
  }
}
