import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import {MatCheckboxModule} from '@angular/material/checkbox';

@Component({
  selector: 'app-adding-tariff',
  templateUrl: './adding-tariff.component.html',
  styleUrls: ['./adding-tariff.component.css']
})
export class AddingTariffComponent implements OnInit {
  Name = '';
  IsArchived = false;
  IsAcceptanceRequired = false;
  IsGradualFinishAvailable = false;
  disableSelect = new FormControl(false);
  TariffTestPeriodUnit = new FormControl(false);
  constructor() { }

  ngOnInit(): void {
  }

}
