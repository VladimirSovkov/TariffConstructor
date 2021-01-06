import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAndChangeSettingsPresetComponent } from './add-and-change-settings-preset.component';

describe('AddAndChangeSettingsPresetComponent', () => {
  let component: AddAndChangeSettingsPresetComponent;
  let fixture: ComponentFixture<AddAndChangeSettingsPresetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAndChangeSettingsPresetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAndChangeSettingsPresetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
