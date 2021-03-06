import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchResult } from '../../search-result.model';
import {ApiService} from '../api.service';
import {SettingsPresetSearchPattern} from '../../model/setting/settings-preset-search-pattern.model';
import {SettingsPreset} from '../../model/setting/settings-preset.model';

@Injectable()
export class SettingsPresetApiServices{
  apiUrl = '/settingsPresets';
  constructor(private http: HttpClient, private apiService: ApiService) {
  }

  search(searchPattern: SettingsPresetSearchPattern): Observable<SearchResult<SettingsPreset>>{
    return this.apiService.search(this.apiUrl + '/search', searchPattern);
  }

  get(id: number): Observable<SettingsPreset>{
    return this.apiService.get(this.apiUrl + '/' + id);
  }

  getAll(): Observable<SettingsPreset[]> {
    return this.apiService.get(this.apiUrl + '/');
  }

  add(settingsPreset: SettingsPreset): Observable<any> {
    return this.apiService.post(this.apiUrl + '/add', settingsPreset);
  }

  update(settingsPreset: SettingsPreset): Observable<any> {
    return this.apiService.post(this.apiUrl + '/', settingsPreset);
  }

  delete(id: number): Observable<any> {
    return this.apiService.delete(this.apiUrl + '/' + id);
  }
}
