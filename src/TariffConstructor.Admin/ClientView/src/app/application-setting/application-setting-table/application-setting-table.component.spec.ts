import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationSettingTableComponent } from './application-setting-table.component';

describe('ApplicationSettingTableComponent', () => {
  let component: ApplicationSettingTableComponent;
  let fixture: ComponentFixture<ApplicationSettingTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationSettingTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationSettingTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
