import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import {SearchResult} from '../search-result.model';
import {BaseSearch} from '../base-search.model';
import {BasePaginationPattern} from '../model/pagination-pattern/base-pagination-pattern.model';
import {PaginationResult} from '../model/pagination-pattern/pagination-result.model';

@Injectable()
export class ApiService{
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin' : 'origin-list'
    })
  };

  constructor(private http: HttpClient) {}

  private formatErrors(error: any): Observable<never> {
    return throwError(error.error);
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http.get( environment.apiUrl + path, {params}).pipe(catchError(this.formatErrors));
  }

  delete(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http.delete( environment.apiUrl + path, {params}).pipe(catchError(this.formatErrors));
  }

  downloadFile(path: string): void {
    const url = environment.apiUrl + path;
    const popupWindow = window.open(url);
    if (!popupWindow || popupWindow.closed || typeof popupWindow.closed === undefined) {
      alert('Please disable your Pop-up blocker and try again.');
    }
  }

  // tslint:disable-next-line:ban-types
  post(path: string, body: Object = {}): Observable<any> {
    return this.http.post(environment.apiUrl + path, JSON.stringify(body), this.httpOptions).pipe(catchError(this.formatErrors));
  }

  search<T extends BaseSearch>(path: string, searchPattern: T): Observable<SearchResult<any>> {
    const params = {};
    Object.keys(searchPattern)
      .filter(key => {
        if (searchPattern[key] !== null && searchPattern[key] !== '') {
          if (Array.isArray(searchPattern[key]) && searchPattern[key].length === 0) {
            return false;
          }
          return true;
        }
        return false;
      })
      .forEach(key => {
        params[key] = searchPattern[key];
      });
    return this.http.get(environment.apiUrl + path, { params }).pipe(catchError(this.formatErrors)) as Observable<SearchResult<any>>;
  }

  pagination<T extends BasePaginationPattern>(path: string, paginationPattern: T): Observable<PaginationResult<any>> {
    const params = {};
    Object.keys(paginationPattern)
      .filter(key => {
        if (paginationPattern[key] !== null && paginationPattern[key] !== '') {
          if (Array.isArray(paginationPattern[key]) && paginationPattern[key].length === 0) {
            return false;
          }
          return true;
        }
        return false;
      })
      .forEach(key => {
        params[key] = paginationPattern[key];
      });
    return this.http.get(environment.apiUrl + path, { params }).pipe(catchError(this.formatErrors)) as Observable<PaginationResult<any>>;
  }

  nestedSearch<T extends BaseSearch>(path: string, searchPattern: T): Observable<any> {
    const params = {};
    Object.keys(searchPattern)
      .filter(key => {
        if (searchPattern[key] !== null && searchPattern[key] !== '') {
          if (Array.isArray(searchPattern[key]) && searchPattern[key].length === 0) {
            return false;
          }
          return true;
        }
        return false;
      })
      .forEach(key => {
        params[key] = searchPattern[key];
      });
    console.log('params: ', params);
    return this.http.get(environment.apiUrl + path, { params }).pipe(catchError(this.formatErrors)) as Observable<any>;
  }
}
