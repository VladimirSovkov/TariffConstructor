import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HelloWorldComponent } from './hello-world/hello-world.component';
import { AddTariffComponent } from './add-tariff/add-tariff.component';

@NgModule({
  declarations: [
      AppComponent,
    HelloWorldComponent,
    AddTariffComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
