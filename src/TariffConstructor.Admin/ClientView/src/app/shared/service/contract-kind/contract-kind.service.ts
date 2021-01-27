import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {ApiService} from '../api.service';
import {Observable} from 'rxjs';
import {SearchResult} from '../../search-result.model';
import {ContractKindSearchPattern} from '../../model/contract-kind/contract-kind-search-pattern.model';
import {ContractKind} from '../../model/contract-kind/contract-kind.model';

@Injectable()
export class ContractKindService{
  apiUrl = '/contractKind';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: ContractKindSearchPattern): Observable<SearchResult<ContractKind>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<ContractKind>{
    return this.apiService.get(this.apiUrl + '/get', new HttpParams().set('id', id.toString()));
  }

  add(contractKind: ContractKind): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', contractKind);
  }

  update(contractKind: ContractKind): Observable<any> {
    return this.apiService.post(this.apiUrl + '/update', contractKind);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/', new HttpParams().set('id', id.toString()));
  }

  getContractKinds(): Observable<ContractKind[]> {
    return this.apiService.get(this.apiUrl + '/getAll');
  }
}
