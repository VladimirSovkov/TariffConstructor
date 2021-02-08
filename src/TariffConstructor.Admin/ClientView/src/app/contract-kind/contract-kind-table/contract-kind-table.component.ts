import {Component, OnInit, ViewChild} from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {MatTable} from '@angular/material/table';
import {SearchResult} from '../../shared/search-result.model';
import {ContractKind} from '../../shared/model/contract-kind/contract-kind.model';
import {ContractKindSearchPattern} from '../../shared/model/contract-kind/contract-kind-search-pattern.model';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {ContractKindService} from '../../shared/service/contract-kind/contract-kind.service';

@Component({
  selector: 'app-contract-kind-table',
  templateUrl: './contract-kind-table.component.html',
  styleUrls: ['./contract-kind-table.component.css']
})
export class ContractKindTableComponent implements OnInit {
  displayedColumns: string[] = ['publicId', 'name', 'action'];
  contractKinds: ContractKind[];
  searchPattern: ContractKindSearchPattern;
  filter = '';
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;
  constructor(private router: Router,
              private contractKindService: ContractKindService,
              private http: HttpClient,
              private snackBarService: SnackBarService) {
    this.searchPattern = new ContractKindSearchPattern();
    this.pageEvent = new PageEvent();
    this.pageEvent.pageIndex = 0;
    this.pageEvent.pageSize = 5;
  }

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.searchPattern.onPage = this.pageEvent.pageSize;
    this.searchPattern.pageNumber = this.pageEvent.pageIndex + 1;
    this.searchPattern.searchString = this.filter;
    this.contractKindService.search(this.searchPattern).subscribe((searchResult: SearchResult<ContractKind>) => {
      this.contractKinds = searchResult.items;
      this.pageEvent.length = searchResult.totalCount;
    }, error => {
      this.snackBarService.openErrorHttpSnackBar(error);
    });
  }

  applyFilter(event: Event): void  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filter = filterValue.trim().toLowerCase();
    this.load();
  }

  delete(contractKind: ContractKind): void{
    this.contractKindService.delete(contractKind.id)
      .subscribe(() => {
        const index = this.contractKinds.indexOf(contractKind, 0);
        if (index > -1) {
          this.contractKinds.splice(index, 1);
        }
        this.table.renderRows();
        this.load();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

}
