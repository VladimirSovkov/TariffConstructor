import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {IncludedProductOptionInTariff} from '../../shared/model/tariff/included-product-option-in-tariff.model';
import {HttpClient} from '@angular/common/http';
import {ProductOption} from '../../shared/model/productOption/product-option.model';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {Tariff} from '../../shared/model/tariff/tariff.model';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {TariffToContractKindBinding} from '../../shared/model/tariff/tariff-to-contract-kind-binding.model';
import {ProductOptionService} from '../../shared/service/product-option/product-option.service';

@Component({
  selector: 'app-add-included-product-option',
  templateUrl: './add-included-product-option.component.html',
  styleUrls: ['./add-included-product-option.component.css']
})
export class AddIncludedProductOptionComponent implements OnInit {
  form: FormGroup;
  productOption: IncludedProductOptionInTariff;
  productOptions: ProductOption[];
  constructor(private http: HttpClient,
              public dialogRef: MatDialogRef<AddIncludedProductOptionComponent>,
              private snackBarService: SnackBarService,
              @Inject(MAT_DIALOG_DATA) public data: IncludedProductOptionInTariff[],
              private productOptionService: ProductOptionService) { }

  ngOnInit(): void {
    this.getProductOption();
    this.form = new FormGroup({
      quantity: new FormControl(0, [Validators.required, Validators.min(1), Validators.pattern('\\d*')]),
      productOptionId: new FormControl('', [Validators.required]),
    });
  }

  getProductOption(): void {
    this.productOptionService.getAll()
      .subscribe( (productOptions: ProductOption[]) => {
        this.productOptions = productOptions.filter( ( el ) => !this.data.map(x => x.productOptionId).includes( el.id ));
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  close(): void {
    this.productOption = this.form.getRawValue();
    this.productOption.id = 0;
    this.productOptionService.get(this.productOption.productOptionId)
      .subscribe((productOption: ProductOption) => {
        this. productOption.productOption = productOption;
        console.log('product-option: ', this.productOption);
        this.dialogRef.close(this.productOption);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
