import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];

export interface Tariff{
  id: number;
  tenantId: number;
  publicId: string;
  name: string;
  paymentType: number;
}

@Component({
  selector: 'app-tariff-table',
  templateUrl: './tariff-table.component.html',
  styleUrls: ['./tariff-table.component.css']
})

export class TariffTableComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'paymentType'];
  dataSource = ELEMENT_DATA;
  tariff: Tariff[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<Tariff[]>('http://localhost:4401/tariff/getTariffs').subscribe(response => {
      this.tariff = response;
    });
  }

}
