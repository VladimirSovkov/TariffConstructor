import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProductOptionComponent } from './add-product-option.component';

describe('AddProductOptionComponent', () => {
  let component: AddProductOptionComponent;
  let fixture: ComponentFixture<AddProductOptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddProductOptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProductOptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
