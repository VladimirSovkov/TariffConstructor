import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddApplicationSettingComponent } from './add-application-setting.component';

describe('AddApplicationSettingComponent', () => {
  let component: AddApplicationSettingComponent;
  let fixture: ComponentFixture<AddApplicationSettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddApplicationSettingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddApplicationSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
