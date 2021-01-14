import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBillingSettingPresetComponent } from './add-billing-setting-preset.component';

describe('AddBillingSettingPresetComponent', () => {
  let component: AddBillingSettingPresetComponent;
  let fixture: ComponentFixture<AddBillingSettingPresetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBillingSettingPresetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBillingSettingPresetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
