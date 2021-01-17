import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAndChangeCurrencyComponent } from './add-and-change-currency.component';

describe('AddAndChangeCurrencyComponent', () => {
  let component: AddAndChangeCurrencyComponent;
  let fixture: ComponentFixture<AddAndChangeCurrencyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAndChangeCurrencyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAndChangeCurrencyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
