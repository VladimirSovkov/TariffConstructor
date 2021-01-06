import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAndChangeBillingSettingComponent } from './add-and-change-billing-setting.component';

describe('AddAndChangeBillingSettingComponent', () => {
  let component: AddAndChangeBillingSettingComponent;
  let fixture: ComponentFixture<AddAndChangeBillingSettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAndChangeBillingSettingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAndChangeBillingSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
