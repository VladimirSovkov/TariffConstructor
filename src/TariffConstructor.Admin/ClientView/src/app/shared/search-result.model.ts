import {Tariff} from './model/tariff.model';

export class SearchResult<T>{
  public items: T[];
  public totalCount: number;
  public filteredCount: number;
}
