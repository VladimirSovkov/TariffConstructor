import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillingSettingTableComponent } from './billing-setting-table.component';

describe('BillingSettingTableComponent', () => {
  let component: BillingSettingTableComponent;
  let fixture: ComponentFixture<BillingSettingTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BillingSettingTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BillingSettingTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
