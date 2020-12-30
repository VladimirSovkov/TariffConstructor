import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';

@Component({
  selector: 'app-change-tariff',
  templateUrl: './change-tariff.component.html',
  styleUrls: ['./change-tariff.component.css']
})
export class ChangeTariffComponent implements OnInit {
  id: number;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
        this.id = params.id;
    });
  }

}
