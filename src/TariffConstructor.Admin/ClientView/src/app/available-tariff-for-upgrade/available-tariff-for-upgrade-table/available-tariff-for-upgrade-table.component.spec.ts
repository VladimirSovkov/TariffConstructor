import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvailableTariffForUpgradeTableComponent } from './available-tariff-for-upgrade-table.component';

describe('AvailableTariffForUpgradeTableComponent', () => {
  let component: AvailableTariffForUpgradeTableComponent;
  let fixture: ComponentFixture<AvailableTariffForUpgradeTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvailableTariffForUpgradeTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AvailableTariffForUpgradeTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
