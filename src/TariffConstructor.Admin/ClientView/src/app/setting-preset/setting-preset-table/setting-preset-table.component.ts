import {Component, OnInit, ViewChild} from '@angular/core';
import {PageEvent} from '@angular/material/paginator';
import {MatTable} from '@angular/material/table';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {SettingsPresetApiServices} from '../../shared/service/setting/settings-preset.service';
import {SettingsPresetSearchPattern} from '../../shared/model/setting/settings-preset-search-pattern.model';
import {SettingsPreset} from '../../shared/model/setting/settings-preset.model';
import {SearchResult} from '../../shared/search-result.model';

@Component({
  selector: 'app-setting-preset-table',
  templateUrl: './setting-preset-table.component.html',
  styleUrls: ['./setting-preset-table.component.css']
})
export class SettingPresetTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'action'];
  filter = '';
  pageEvent: PageEvent;
  searchPattern: SettingsPresetSearchPattern;
  settingsPresets: SettingsPreset[];
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild(MatTable) table: MatTable<any>;

  constructor(private router: Router,
              private http: HttpClient,
              private snackBarService: SnackBarService,
              private settingsPresetService: SettingsPresetApiServices) {
    this.searchPattern = new SettingsPresetSearchPattern();
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
    this.settingsPresetService.search(this.searchPattern).subscribe((searchResult: SearchResult<SettingsPreset>) => {
      this.settingsPresets = searchResult.items;
      this.pageEvent.length = searchResult.totalCount;
    }, error => {
      this.snackBarService.openErrorSnackBar(error);
    });
  }

  applyFilter(event: Event): void  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filter = filterValue.trim().toLowerCase();
    this.load();
  }

  delete(settingsPreset: SettingsPreset): void{
    this.settingsPresetService.delete(settingsPreset.id)
      .subscribe(() => {
        const index = this.settingsPresets.indexOf(settingsPreset, 0);
        if (index > -1) {
          this.settingsPresets.splice(index, 1);
        }
        this.table.renderRows();
      }, error => {
        this.snackBarService.openErrorSnackBar(error);
      });
  }

}
