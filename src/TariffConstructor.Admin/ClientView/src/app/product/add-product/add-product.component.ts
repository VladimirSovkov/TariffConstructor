import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Product} from '../../shared/model/product/product.model';
import {HttpClient} from '@angular/common/http';
import {MatSnackBar} from '@angular/material/snack-bar';
import {ProductService} from '../../shared/service/product/product.service';
import {SnackBarService} from '../../shared/service/snack-bar.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  isChangeProduct = false;
  id: number;
  form: FormGroup;
  product: Product;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private snackBarService: SnackBarService,
              private productService: ProductService) { }

  ngOnInit(): void {
    this.formInitialization();
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.loadProduct(this.id);
        this.isChangeProduct = true;
        console.log('id: ', this.id);
      }
    });
  }

  private formInitialization(): void {
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      publicId: new FormControl('', [Validators.required]),
      nomenclatureId: new FormControl('', [Validators.required]),
      shortName: new FormControl('', [Validators.required]),
    });
  }

  action(): void {
    this.product = this.form.getRawValue();
    if (this.isChangeProduct)
    {
      this.changeProduct(this.product);
    }
    else
    {
      this.addProduct(this.product);
    }
  }

  loadProduct(id: number): void{
    this.productService.get(id)
      .subscribe((product: Product) => {
        this.product = product;
        this.form.patchValue(product);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  addProduct(product: Product): void{
    this.productService.add(product)
      .subscribe(() => {
        this.formInitialization();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  changeProduct(product: Product): void {
    this.product.id = this.id;
    console.log('product: ', this.product);
    this.productService.update(product)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['product']);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

}
