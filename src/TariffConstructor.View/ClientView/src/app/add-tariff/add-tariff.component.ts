import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-tariff',
  templateUrl: './add-tariff.component.html',
  styleUrls: ['./add-tariff.component.css']
})
export class AddTariffComponent {
  tariff: string;
  constructor() { }

  onBlur(str: string): void {
    this.tariff = str;
  }

}
