import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Tariff} from '../model/tariff.model';
import {TariffSearchPattern} from '../tariff-search-pattern.model';
import {SearchResult} from '../search-result.model';

@Injectable()
export class TariffService{
  aoiUrl = 'здесь мой апи';
  serach: SearchResult<Tariff>;
  constructor(private http: HttpClient) {}

  getData(searchPattern: TariffSearchPattern): Observable<SearchResult<Tariff>>{
    const params = new HttpParams()
      .set('pageNumber', searchPattern.pageNumber.toString())
      .set('onPage', searchPattern.onPage.toString())
      .set('searchString', searchPattern.searchString.toString());
    return this.http.get<SearchResult<Tariff>>('http://localhost:4401/test/search', {params});
  }
}
