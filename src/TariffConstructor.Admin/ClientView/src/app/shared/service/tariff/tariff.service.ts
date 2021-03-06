import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {ApiService} from '../api.service';
import {Observable} from 'rxjs';
import {TariffSearchPattern} from '../../tariff-search-pattern.model';
import {SearchResult} from '../../search-result.model';
import {Tariff} from '../../model/tariff/tariff.model';

@Injectable()
export class TariffService{
  apiUrl = '/tariffs';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: TariffSearchPattern): Observable<SearchResult<Tariff>> {
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<Tariff>{
    return this.apiService.get(this.apiUrl + '/' + id);
  }

  add(tariff: Tariff): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', tariff);
  }

  update(tariff: Tariff): Observable<any> {
    return this.apiService.post(this.apiUrl + '/', tariff);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/' + id);
  }

  getAll(): Observable<Tariff[]>{
    return this.apiService.get(this.apiUrl + '/');
  }
}
