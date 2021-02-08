import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchResult } from '../../search-result.model';
import {Setting} from '../../model/setting/setting.model';
import {SettingSearchPattern} from '../../model/setting/setting-search-pattern.model';
import {ApiService} from '../api.service';

@Injectable()
export class SettingApiServices{
  apiUrl = '/settings';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: SettingSearchPattern): Observable<SearchResult<Setting>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<Setting>{
    return this.apiService.get(this.apiUrl + '/' + id);
  }

  add(setting: Setting): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', setting);
  }

  update(setting: Setting): Observable<any> {
    return this.apiService.post(this.apiUrl + '/', setting);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/' + id);
  }

  getSettings(): Observable<Setting[]> {
    return this.apiService.get(this.apiUrl + '/');
  }
}
