import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add-product-option',
  templateUrl: './add-product-option.component.html',
  styleUrls: ['./add-product-option.component.css']
})
export class AddProductOptionComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  goBack(): void {
    this.router.navigate(['/productOption']);
  }
}
