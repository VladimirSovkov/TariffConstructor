import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {ContractKind} from '../../shared/model/contract-kind/contract-kind.model';
import {ContractKindService} from '../../shared/service/contract-kind/contract-kind.service';
import {SnackBarService} from '../../shared/service/snack-bar.service';

@Component({
  selector: 'app-add-and-change-contract-kind',
  templateUrl: './add-and-change-contract-kind.component.html',
  styleUrls: ['./add-and-change-contract-kind.component.css']
})
export class AddAndChangeContractKindComponent implements OnInit {
  isChange = false;
  id: number;
  form: FormGroup;
  contractKind: ContractKind;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient,
              private contractKindService: ContractKindService,
              private snackBarService: SnackBarService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params.id;
      if (this.id)
      {
        this.load(this.id);
        this.isChange = true;
      }
    });
    this.formInitialization();
  }

  formInitialization(): void{
    this.form = new FormGroup({
      publicId: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
    });
  }

  action(): void {
    this.contractKind = new ContractKind();
    this.contractKind = this.form.getRawValue();
    this.contractKind.id = this.id;
    console.log('application: ', this.contractKind);
    if (this.isChange){
      this.updateApplication(this.contractKind);
    }
    else {
      this.addApplication(this.contractKind);
    }
  }

  load(id: number): void {
    this.contractKindService.get(id)
      .subscribe( (contractKind: ContractKind) => {
        this.contractKind = contractKind;
        this.form.patchValue(contractKind);
        console.log('contractKind: ', this.contractKind);
      },  error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  addApplication(contractKind: ContractKind): void {
    this.contractKindService.add(contractKind)
      .subscribe(() => {
        console.log('При добавлении сервер ответил: Ok');
        this.formInitialization();
      },  error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  updateApplication(contractKind: ContractKind): void {
    this.contractKindService.update(contractKind)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['/contractKind']);
      },  error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
