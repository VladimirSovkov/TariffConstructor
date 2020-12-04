import {HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import construct = Reflect.construct;
import {BaseSearch} from '../base-search.model';
import {SearchResult} from '../search-result.model';
import {Tariff} from '../model/tariff.model';

@Injectable()
export class classApiService
{
  url = 'http://localhost:4401/';
  constructor(private http: HttpClient)
  {}

  search(apiUrl: string, searchPattern: BaseSearch): Observable<SearchResult<Tariff>>{
    const params = new HttpParams()
      .set('pageNumber', searchPattern.pageNumber.toString())
      .set('onPage', searchPattern.onPage.toString())
      .set('searchString', searchPattern.searchString.toString());
    return this.http.get<SearchResult<Tariff>>( this.url + apiUrl, {params});
  }
}

