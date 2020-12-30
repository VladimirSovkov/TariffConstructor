import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import {ApiService} from '../api.service';
import {ApplicationSetting} from '../../model/application-setting/application-setting.model';
import {ApplicationSettingPaginationPattern} from '../../model/application-setting/application-setting-pagination-pattern.model';
import {PaginationResult} from '../../model/pagination-pattern/pagination-result.model';

@Injectable()
export class ApplicationSettingApiServices{
  apiUrl = '/applicationSetting';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  pagination(paginationPattern: ApplicationSettingPaginationPattern): Observable<PaginationResult<ApplicationSetting>> {
    return this.apiService.pagination(this.apiUrl + '/pagination', paginationPattern);
  }

  get(id: number): Observable<ApplicationSetting>{
    return this.apiService.get(this.apiUrl + '/getApplicationSetting', new HttpParams().set('id', id.toString()));
  }

  add(setting: ApplicationSetting): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', setting);
  }

  update(setting: ApplicationSetting): Observable<any> {
    return this.apiService.post(this.apiUrl + '/update', setting);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/', new HttpParams().set('id', id.toString()));
  }
}
