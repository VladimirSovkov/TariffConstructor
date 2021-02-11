import {Component, OnDestroy, OnInit} from '@angular/core';
import {SearchResult} from '../../../../shared/search-result.model';
import {Application} from '../../../../shared/model/application/application.model';
import {ApplicationSearchPattern} from '../../../../shared/model/application/application-search-pattern.model';
import {ApplicationApiService} from '../../../../shared/service/application/application-api.service';
import {BehaviorSubject, forkJoin, Subscription} from 'rxjs';

@Component({
  selector: 'app-application-table-page',
  templateUrl: './application-table-page.component.html',
  styleUrls: ['./application-table-page.component.css']
})
export class ApplicationTablePageComponent implements OnInit, OnDestroy {
  searchPattern: ApplicationSearchPattern = new ApplicationSearchPattern();
  applications: Application[];
  private _application$ = new BehaviorSubject<Application[]>( [] );
  private _subscription = new Subscription();
  constructor(private applicationService: ApplicationApiService) {

  }

  ngOnInit(): void {

   this.load();
  }

  public ngOnDestroy(): void {
    this._subscription.unsubscribe();
  }

  load(): void {
    this.searchPattern.onPage = 5;
    this.searchPattern.pageNumber = 1;
    this.applicationService.search(this.searchPattern).subscribe((searchResult: SearchResult<Application>) => {
      this.applications = searchResult.items;
      this._application$.next(this.applications);
      console.log('application-page: ', this.applications);
    });
  }

  applyFilter($event: KeyboardEvent): void {
  }
}
