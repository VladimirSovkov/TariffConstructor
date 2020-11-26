import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTariffComponent } from './add-tariff.component';

describe('AddTariffComponent', () => {
  let component: AddTariffComponent;
  let fixture: ComponentFixture<AddTariffComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTariffComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTariffComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
