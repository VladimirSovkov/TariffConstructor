import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import {ApiService} from '../api.service';
import {PaginationResult} from '../../model/pagination-pattern/pagination-result.model';
import {BillingSetting} from '../../model/billing-setting/billing-setting/billing-setting.model';
import {BillingSettingPaginationPattern} from '../../model/billing-setting/billing-setting/billing-setting-pagination-pattern.model';

@Injectable()
export class BillingSettingApiServices{
  apiUrl = '/billingSettings';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  pagination(paginationPattern: BillingSettingPaginationPattern): Observable<PaginationResult<BillingSetting>> {
    return this.apiService.pagination(this.apiUrl + '/pagination', paginationPattern);
  }

  get(id: number): Observable<BillingSetting> {
    return this.apiService.get(this.apiUrl + '/' + id);
  }

  getAll(): Observable<BillingSetting[]>{
    return this.apiService.get(this.apiUrl + '/');
  }

  add(setting: BillingSetting): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', setting);
  }

  update(setting: BillingSetting): Observable<any> {
    return this.apiService.post(this.apiUrl + '/', setting);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/' + id);
  }
}
