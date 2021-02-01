import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddIncludedProductComponent } from './add-included-product.component';

describe('AddIncludedProductComponent', () => {
  let component: AddIncludedProductComponent;
  let fixture: ComponentFixture<AddIncludedProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddIncludedProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddIncludedProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
