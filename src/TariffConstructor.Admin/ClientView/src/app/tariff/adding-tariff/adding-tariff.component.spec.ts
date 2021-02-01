import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddingTariffComponent } from './adding-tariff.component';

describe('AddingTariffComponent', () => {
  let component: AddingTariffComponent;
  let fixture: ComponentFixture<AddingTariffComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddingTariffComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddingTariffComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
