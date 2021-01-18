import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAndChangeProductOptionTariffComponent } from './add-and-change-product-option-tariff.component';

describe('AddAndChangeProductOptionTariffComponent', () => {
  let component: AddAndChangeProductOptionTariffComponent;
  let fixture: ComponentFixture<AddAndChangeProductOptionTariffComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAndChangeProductOptionTariffComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAndChangeProductOptionTariffComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
