import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {ApiService} from '../api.service';
import {Observable} from 'rxjs';
import {SearchResult} from '../../search-result.model';
import {Currency} from '../../model/currency/currency.model';
import {CurrencySearchPattern} from '../../model/currency/currency-search-pattern.model';

@Injectable()
export class CurrencyService {
  apiUrl = '/currencies';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: CurrencySearchPattern): Observable<SearchResult<Currency>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<Currency>{
    return this.apiService.get(this.apiUrl + '/' + id);
  }

  add(currency: Currency): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', currency);
  }

  update(currency: Currency): Observable<any> {
    return this.apiService.post(this.apiUrl + '/', currency);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/' + id);
  }

  getCurrencies(): Observable<Currency[]> {
    return this.apiService.get(this.apiUrl + '/');
  }
}
