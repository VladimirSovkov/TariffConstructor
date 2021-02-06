import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {SnackBarService} from '../../shared/service/snack-bar.service';
import {AvailableTariffForUpgradeService} from '../services/available-tariff-for-upgrade.service';
import {AvailableTariffForUpgrade} from '../models/available-tariff-for-upgrade.model';
import {Tariff} from '../../shared/model/tariff/tariff.model';
import {TariffService} from '../../shared/service/tariff/tariff.service';

@Component({
  selector: 'app-add-and-change-available-tariff-for-upgrade',
  templateUrl: './add-and-change-available-tariff-for-upgrade.component.html',
  styleUrls: ['./add-and-change-available-tariff-for-upgrade.component.css']
})
export class AddAndChangeAvailableTariffForUpgradeComponent implements OnInit {
  availableTariffForUpgrade: AvailableTariffForUpgrade;
  tariffs: Tariff[];
  isChange = false;
  id: number;
  form: FormGroup;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private availableTariffForUpgradeService: AvailableTariffForUpgradeService,
              private  snackBarService: SnackBarService,
              private tariffService: TariffService) { }

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
    this.loadTariff();
  }

  formInitialization(): void{
    this.form = new FormGroup({
      fromTariff: new FormControl('', [Validators.required]),
      toTariff: new FormControl('', [Validators.required]),
    });
  }

  action(): void {
    this.availableTariffForUpgrade = new AvailableTariffForUpgrade();
    this.availableTariffForUpgrade = this.form.getRawValue();
    this.availableTariffForUpgrade.id = this.id;
    if (this.isChange){
      this.update(this.availableTariffForUpgrade);
    }
    else {
      this.add(this.availableTariffForUpgrade);
    }
  }

  load(id: number): void {
    this.availableTariffForUpgradeService.get(id)
      .subscribe( (availableTariffForUpgrade: AvailableTariffForUpgrade) => {
        this.availableTariffForUpgrade = availableTariffForUpgrade;
        this.form.patchValue(availableTariffForUpgrade);
      });
  }

  add(availableTariffForUpgrade: AvailableTariffForUpgrade): void {
    console.log(availableTariffForUpgrade);
    this.availableTariffForUpgrade.id = 0;
    this.availableTariffForUpgradeService.add(availableTariffForUpgrade)
      .subscribe(() => {
        this.formInitialization();
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  update(availableTariffForUpgrade: AvailableTariffForUpgrade): void {
    this.availableTariffForUpgradeService.update(availableTariffForUpgrade)
      .subscribe(() => {
        this.formInitialization();
        this.router.navigate(['/availableTariffForUpgrade']);
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }

  private loadTariff(): void{
    this.tariffService.getAll()
      .subscribe((tariffs: Tariff[]) => {
        this.tariffs = tariffs;
      }, error => {
        this.snackBarService.openErrorHttpSnackBar(error);
      });
  }
}
