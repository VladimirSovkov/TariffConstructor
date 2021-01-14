import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddApplicationSettingPresetsComponent } from './add-application-setting-presets.component';

describe('AddApplicationSettingPresetsComponent', () => {
  let component: AddApplicationSettingPresetsComponent;
  let fixture: ComponentFixture<AddApplicationSettingPresetsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddApplicationSettingPresetsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddApplicationSettingPresetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
