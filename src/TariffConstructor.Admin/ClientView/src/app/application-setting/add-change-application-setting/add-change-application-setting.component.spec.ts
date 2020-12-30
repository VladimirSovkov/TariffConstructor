import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddChangeApplicationSettingComponent } from './add-change-application-setting.component';

describe('AddChangeApplicationSettingComponent', () => {
  let component: AddChangeApplicationSettingComponent;
  let fixture: ComponentFixture<AddChangeApplicationSettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddChangeApplicationSettingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddChangeApplicationSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
