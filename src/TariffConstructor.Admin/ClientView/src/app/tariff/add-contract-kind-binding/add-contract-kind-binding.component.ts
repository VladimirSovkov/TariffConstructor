import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {ContractKind} from '../../shared/model/contract-kind/contract-kind.model';
import {ContractKindService} from '../../shared/service/contract-kind/contract-kind.service';
import {TariffToContractKindBinding} from '../../shared/model/tariff/tariff-to-contract-kind-binding.model';
import {IncludedProductInTariff} from '../../shared/model/tariff/included-product-In-tariff.model';

@Component({
  selector: 'app-add-contract-kind-binding',
  templateUrl: './add-contract-kind-binding.component.html',
  styleUrls: ['./add-contract-kind-binding.component.css']
})
export class AddContractKindBindingComponent implements OnInit {
  form: FormGroup;
  contractKinds: ContractKind[] = [];
  contractKindBinding: TariffToContractKindBinding;
  constructor(public dialogRef: MatDialogRef<AddContractKindBindingComponent>,
              private snackBarService: SnackBarService,
              private contractKindService: ContractKindService,
              @Inject(MAT_DIALOG_DATA) public data: TariffToContractKindBinding[]) { }

  ngOnInit(): void {
    this.initializationForm();
    this.loadContractKinds();
  }

  private initializationForm(): void {
    this.form = new FormGroup({
      contractKindId: new FormControl('', [Validators.required])
    });
  }

  close(): void {
    this.contractKindBinding = this.form.getRawValue();
    this.contractKindBinding.id = 0;
    console.log('contractKindBinding: ', this.contractKindBinding);
    this.dialogRef.close(this.contractKindBinding);
  }

  private loadContractKinds(): void {
    this.contractKindService.getContractKinds()
      .subscribe((contractKinds: ContractKind[]) => {
        this.contractKinds = contractKinds.filter( ( el ) => !this.data.map(x => x.contractKindId).includes( el.id ) );
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
