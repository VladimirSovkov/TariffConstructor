import {Component, Inject, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from '@angular/material/dialog';
import {Product} from '../../shared/model/product/product.model';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Tariff} from '../../shared/model/tariff/tariff.model';
import {IncludedProductInTariff} from '../../shared/model/tariff/included-product-In-tariff.model';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {ProductService} from '../../shared/service/product/product.service';

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
              @Inject(MAT_DIALOG_DATA) public data: IncludedProductInTariff[],
              private snackBarService: SnackBarService,
              private productService: ProductService) {
  }

  ngOnInit(): void {
    this.getProduct();
    this.form = new FormGroup({
      productId: new FormControl('', [Validators.required]),
      relativeWeight: new FormControl(0, [Validators.required, Validators.pattern('\\d*'), Validators.min(0)] )
    });
  }

  getProduct(): void {
    this.productService.getProducts()
      .subscribe((products: Product[]) => {
        this.products = products.filter( ( el ) => !this.data.map(x => x.productId).includes( el.id ) );

      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      })
  }

  close(): void {
    this.includedProduct = this.form.getRawValue();
    this.includedProduct.id = 0;
    this.productService.get(this.includedProduct.productId)
      .subscribe((product: Product) => {
        this.includedProduct.product = product;
        console.log(this.includedProduct);
        this.dialogRef.close(this.includedProduct);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
