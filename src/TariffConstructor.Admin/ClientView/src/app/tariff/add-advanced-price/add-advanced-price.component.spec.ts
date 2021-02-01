import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAdvancedPriceComponent } from './add-advanced-price.component';

describe('AddAdvancedPriceComponent', () => {
  let component: AddAdvancedPriceComponent;
  let fixture: ComponentFixture<AddAdvancedPriceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAdvancedPriceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAdvancedPriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
