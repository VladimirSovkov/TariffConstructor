import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AddAndChangeApplicationRoutingModule} from './add-and-change-application-routing.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSortModule} from '@angular/material/sort';
import {MatButtonModule} from '@angular/material/button';
import {AddAndChangeApplicationComponent} from './components/add-and-change-application/add-and-change-application.component';
import {MatInputModule} from '@angular/material/input';

@NgModule({
  declarations: [AddAndChangeApplicationComponent],
  imports: [
    CommonModule,
    AddAndChangeApplicationRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatSortModule,
    MatButtonModule,
  ],
  exports: [],
  providers: []
})

export class AddAndChangeApplicationModule{
}
