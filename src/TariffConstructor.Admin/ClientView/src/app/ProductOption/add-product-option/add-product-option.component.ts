import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ProductOption} from '../../shared/model/ProductOption/product-option.model';
import {Product} from '../../shared/model/Product/product.model';

@Component({
  selector: 'app-add-product-option',
  templateUrl: './add-product-option.component.html',
  styleUrls: ['./add-product-option.component.css']
})
export class AddProductOptionComponent implements OnInit {
  isChangeProductOption = false;
  id: number;
  form: FormGroup;
  productOption: ProductOption;
  products: Product[];
  constructor(private router: Router, private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    this.loadProducts();
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.loadProductOption(this.id);
        this.isChangeProductOption = true;
      }
    });

    this.form = new FormGroup({
      productId:  new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      isMultiple: new FormControl( false),
      accountingName: new FormControl('', [Validators.required]),
      nomenclatureId: new FormControl('', [Validators.required])
    });
  }

  action(): void{
    this.productOption = this.form.getRawValue();
    this.productOption.id = this.id;
    console.log('productOption: ', this.productOption);
    // if (this.isChangeProductOption)
    // {
    //   this.changeProductOption();
    // }
    // else
    // {
    //   this.addProductOption();
    // }
  }

  loadProductOption(id: number): void {
    this.http.get<ProductOption>('http://localhost:4401/productOption/get?id=' +  this.id)
      .subscribe( (productOption: ProductOption)  => {
        this.productOption = productOption;
        this.form.patchValue(this.productOption);
      });
  }

  loadProducts(): void {
    this.http.get<Product[]>('http://localhost:4401/product/GetProducts')
      .subscribe((products: Product[]) => {
        this.products = products;
      });
  }

  addProductOption(): void {
    this.http.post('http://localhost:4401/productOption/add', this.productOption)
      .subscribe( () => {
        this.form.reset();
      });
  }

  changeProductOption(): void {
    console.log('productOption: ', this.productOption);
    this.http.post('http://localhost:4401/productOption/change', this.productOption)
      .subscribe( () => {
        this.form.reset();
      });
  }
}
