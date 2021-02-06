import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAndChangeAvailableTariffForUpgradeComponent } from './add-and-change-available-tariff-for-upgrade.component';

describe('AddAndChangeAvailableTariffForUpgradeComponent', () => {
  let component: AddAndChangeAvailableTariffForUpgradeComponent;
  let fixture: ComponentFixture<AddAndChangeAvailableTariffForUpgradeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAndChangeAvailableTariffForUpgradeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAndChangeAvailableTariffForUpgradeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
