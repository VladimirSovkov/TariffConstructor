import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddChangeSettingComponent } from './add-change-setting.component';

describe('AddChangeSettingComponent', () => {
  let component: AddChangeSettingComponent;
  let fixture: ComponentFixture<AddChangeSettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddChangeSettingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddChangeSettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
