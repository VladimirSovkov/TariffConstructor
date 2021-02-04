import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ApiService} from '../../shared/service/api.service';
import {PaginationResult} from '../../shared/model/pagination-pattern/pagination-result.model';
import {AvailableTariffForUpgrade} from '../models/available-tariff-for-upgrade.model';
import {AvailableTariffForUpgradePaginationPattern} from '../models/available-tariff-for-upgrade-pagination-pattern.model';

@Injectable()
export class AvailableTariffForUpgradeService{
  apiUrl = '/availableTariffsForUpgrade';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  pagination(paginationPattern: AvailableTariffForUpgradePaginationPattern): Observable<PaginationResult<AvailableTariffForUpgrade>>{
    return this.apiService.pagination(this.apiUrl + '/pagination', paginationPattern);
  }

  get(id: number): Observable<AvailableTariffForUpgrade>{
    return this.apiService.get(this.apiUrl + '/', new HttpParams().set('id', id.toString()));
  }

  add(availableTariffForUpgrade: AvailableTariffForUpgrade): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', availableTariffForUpgrade);
  }

  update(availableTariffForUpgrade: AvailableTariffForUpgrade): Observable<any> {
    return this.apiService.post(this.apiUrl + '/', availableTariffForUpgrade);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/', new HttpParams().set('id', id.toString()));
  }

  getAll(): Observable<AvailableTariffForUpgrade[]> {
    return this.apiService.get(this.apiUrl + '/');
  }
}
