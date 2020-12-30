import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAdvancePriceComponent } from './add-advance-price.component';

describe('AddAdvancePriceComponent', () => {
  let component: AddAdvancePriceComponent;
  let fixture: ComponentFixture<AddAdvancePriceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAdvancePriceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAdvancePriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
