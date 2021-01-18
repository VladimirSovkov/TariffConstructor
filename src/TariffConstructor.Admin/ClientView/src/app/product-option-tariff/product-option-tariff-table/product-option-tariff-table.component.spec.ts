import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductOptionTariffTableComponent } from './product-option-tariff-table.component';

describe('ProductOptionTariffTableComponent', () => {
  let component: ProductOptionTariffTableComponent;
  let fixture: ComponentFixture<ProductOptionTariffTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductOptionTariffTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductOptionTariffTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
