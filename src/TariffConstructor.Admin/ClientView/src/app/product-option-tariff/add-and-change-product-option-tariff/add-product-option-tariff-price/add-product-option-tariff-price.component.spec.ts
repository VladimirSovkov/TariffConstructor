import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProductOptionTariffPriceComponent } from './add-product-option-tariff-price.component';

describe('AddProductOptionTariffPriceComponent', () => {
  let component: AddProductOptionTariffPriceComponent;
  let fixture: ComponentFixture<AddProductOptionTariffPriceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddProductOptionTariffPriceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProductOptionTariffPriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
