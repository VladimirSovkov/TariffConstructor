import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ProductOption} from '../../shared/model/productOption/product-option.model';
import {Product} from '../../shared/model/product/product.model';
import {ProductService} from '../../shared/service/product/product.service';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {ProductOptionService} from '../../shared/service/product-option/product-option.service';

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
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private productService: ProductService,
              private productOptionService: ProductOptionService,
              private snackBarService: SnackBarService) { }

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
    this.formInitialization();

  }

  private formInitialization(): void {
    this.form = new FormGroup({
      productId:  new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      publicId: new FormControl('', [Validators.required]),
      isMultiple: new FormControl( false),
      accountingName: new FormControl(''),
      nomenclatureId: new FormControl('', [Validators.required])
    });
  }

  action(): void{
    this.productOption = this.form.getRawValue();
    this.productOption.id = this.id;
    console.log('product-option: ', this.productOption);
    if (this.isChangeProductOption)
    {
      this.changeProductOption(this.productOption);
    }
    else
    {
      this.addProductOption(this.productOption);
    }
  }

  loadProductOption(id: number): void {
    this.productOptionService.get(id)
      .subscribe((productOption: ProductOption) => {
        this.productOption = productOption;
        this.form.patchValue(this.productOption);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  loadProducts(): void {
    this.productService.getProducts()
      .subscribe((products: Product[]) => {
        this.products = products;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  addProductOption(productOption: ProductOption): void {
    this.productOptionService.add(productOption)
      .subscribe(() => {
        this.formInitialization();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  changeProductOption(productOption: ProductOption): void {
    this.productOptionService.update(productOption)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['productOption']);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
