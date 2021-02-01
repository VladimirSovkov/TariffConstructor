import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddIncludedProductOptionComponent } from './add-included-product-option.component';

describe('AddIncludedProductOptionComponent', () => {
  let component: AddIncludedProductOptionComponent;
  let fixture: ComponentFixture<AddIncludedProductOptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddIncludedProductOptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddIncludedProductOptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
