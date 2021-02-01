import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBillingSettingComponent } from './add-billing-setting.component';

describe('AddBillingSettingComponent', () => {
  let component: AddBillingSettingComponent;
  let fixture: ComponentFixture<AddBillingSettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBillingSettingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBillingSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
