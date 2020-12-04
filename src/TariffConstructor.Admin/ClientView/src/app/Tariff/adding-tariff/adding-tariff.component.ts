import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-adding-tariff',
  templateUrl: './adding-tariff.component.html',
  styleUrls: ['./adding-tariff.component.css']
})

export class AddingTariffComponent implements OnInit {
  form: FormGroup;
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      isArchived: new FormControl( false),
      Value: new FormControl( 0),
      AccountingName: new FormControl(''),
      AwaitingPaymentStrategy: new FormControl(''),
      AccountingTariffId: new FormControl(''),
      SettingsPresetId: new FormControl( 0),
      TermsOfUseId: new FormControl( 0),
      IsAcceptanceRequired: new FormControl( false),
      IsGradualFinishAvailable: new FormControl( false),
      PaymentType: new FormControl('0'),
      Unit: new FormControl('0')
    });
  }

  addTariff(): void {
    this.http.post('http://localhost:4401/test/post',  this.form.value)
      .subscribe(todo => {
       console.log('todo', todo);
       this.form.reset();
      });
  }

  goBack(): void {
    this.router.navigate(['']);
  }
}
