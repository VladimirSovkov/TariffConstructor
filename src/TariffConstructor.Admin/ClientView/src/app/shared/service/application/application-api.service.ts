import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {ApiService} from '../api.service';
import {Observable} from 'rxjs';
import {SearchResult} from '../../search-result.model';
import {ApplicationSearchPattern} from '../../model/application/application-search-pattern.model';
import {Application} from '../../model/application/application.model';

@Injectable()
export class ApplicationApiService{
  apiUrl = '/applications';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: ApplicationSearchPattern): Observable<SearchResult<Application>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<Application>{
    return this.apiService.get(this.apiUrl + '/' + id);
  }

  add(application: Application): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', application);
  }

  update(application: Application): Observable<any> {
    return this.apiService.post(this.apiUrl + '/', application);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/' + id);
  }

  getApplications(): Observable<Application[]> {
    return this.apiService.get(this.apiUrl + '/');
  }
}
