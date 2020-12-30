import {Component, Inject, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from '@angular/material/dialog';
import {Product} from '../../shared/model/Product/product.model';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Tariff} from '../../shared/model/TariffAggregate/tariff.model';
import {IncludedProductInTariff} from '../../shared/model/TariffAggregate/included-product-In-tariff.model';

@Component({
  selector: 'app-add-included-product',
  templateUrl: './add-included-product.component.html',
  styleUrls: ['./add-included-product.component.css']
})
export class AddIncludedProductComponent implements OnInit {
  products: Product[];
  includedProduct: IncludedProductInTariff;
  form: FormGroup;

  constructor(private http: HttpClient,
              public dialogRef: MatDialogRef<AddIncludedProductComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Tariff) {
  }

  ngOnInit(): void {
    this.getProduct();
    this.form = new FormGroup({
      productId: new FormControl('', [Validators.required]),
      relativeWeight: new FormControl(0, [Validators.required] )
    });
  }

  getProduct(): void {
    this.http.get<Product[]>('http://localhost:4401/product/GetProducts')
      .subscribe((products: Product[]) => {
        this.products = products;
      });
  }

  addProduct(): void {
    this.includedProduct = this.form.getRawValue();
    this.includedProduct.id = 0;
    this.includedProduct.tariffId = (this.data.id === undefined) ? 0 : this.data.id;
    this.data.includedProducts.push(this.includedProduct);
  }
}
