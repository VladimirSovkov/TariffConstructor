import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingPresetTableComponent } from './setting-preset-table.component';

describe('SettingPresetTableComponent', () => {
  let component: SettingPresetTableComponent;
  let fixture: ComponentFixture<SettingPresetTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SettingPresetTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingPresetTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
