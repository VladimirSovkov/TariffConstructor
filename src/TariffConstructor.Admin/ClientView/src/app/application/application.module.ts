import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AddAndChangeApplicationModule} from './add-and-change-application/add-and-change-application.module';
import {ApplicationTableModule} from './application-table/application-table.module';
import {ApplicationTableComponent} from './application-table/components/application-table.component';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AddAndChangeApplicationModule,
    ApplicationTableModule
  ],
  exports: [],
  providers: []
})
export class ApplicationModule { }
