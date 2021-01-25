import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Product} from '../../shared/model/product/product.model';
import {HttpClient} from '@angular/common/http';
import {MatSnackBar} from '@angular/material/snack-bar';

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
  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.loadProduct(this.id);
        this.isChangeProduct = true;
        console.log('id: ', this.id);
      }
    });

    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      nomenclatureId: new FormControl('', [Validators.required]),
      shortName: new FormControl('', [Validators.required]),
    });

  }

  action(): void {
    this.product = this.form.getRawValue();
    if (this.isChangeProduct)
    {
      this.changeProduct();
    }
    else
    {
      this.addProduct();
    }
  }

  loadProduct(id: number): void{
    this.http.get<Product>('http://localhost:4401/product/get?id=' + this.id)
      .subscribe((product: Product) => {
        this.product = product;
        this.form.patchValue(product);
      },
        () => {
          this.openErrorSnackBar('Не могу загрузить данные продукта с id = ' + this.id);
        });
  }

  addProduct(): void{
    this.http.post('http://localhost:4401/product/add', this.product)
      .subscribe( () => {
        this.form.reset();
        this.openSuccessSnackBar('Продукт усппешно добавлен!');
      },
        () => {
        this.openErrorSnackBar('Ошибка в добавлении проудкта.');
        });
  }

  changeProduct(): void {
    this.product.id = this.id;
    console.log('product: ', this.product);
    this.http.post('http://localhost:4401/product/update', this.product)
      .subscribe( () => {
        this.form.reset();
        this.openSuccessSnackBar('Продукт успешно изменен.');
      },
        () => {
        this.openErrorSnackBar('Ошибка в изменении продукта.');
        });
  }

  openSuccessSnackBar(message: string): void {
    this.snackBar.open(message, 'Закрыть', {
      duration: 3000,
      panelClass: ['blue-snackbar']
    });
  }

  openErrorSnackBar(message: string): void {
    this.snackBar.open(message, '', {
      duration: 3000,
      panelClass: ['mat-toolbar', 'mat-warn']
    });
  }

}
