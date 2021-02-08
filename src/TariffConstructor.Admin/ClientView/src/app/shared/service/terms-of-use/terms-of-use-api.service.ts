import {TermsOfUseSearchPattern} from '../../model/terms-of-use/terms-of-use-search-pattern.model';
import {TermsOfUse} from '../../model/terms-of-use/terms-of-use.model';
import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {ApiService} from '../api.service';
import {Observable} from 'rxjs';
import {SearchResult} from '../../search-result.model';

@Injectable()
export class TermsOfUseApiService{
  apiUrl = '/termsOfUses';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: TermsOfUseSearchPattern): Observable<SearchResult<TermsOfUse>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<TermsOfUse>{
    return this.apiService.get(this.apiUrl + '/' + id);
  }

  add(termsOfUse: TermsOfUse): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', termsOfUse);
  }

  update(termsOfUse: TermsOfUse): Observable<any> {
    return this.apiService.post(this.apiUrl + '/', termsOfUse);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/' + id);
  }

  getTermsOfUses(): Observable<TermsOfUse[]> {
    return this.apiService.get(this.apiUrl + '/');
  }
}
