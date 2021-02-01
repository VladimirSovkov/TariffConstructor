import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAndChangeTariffComponent } from './add-and-change-tariff.component';

describe('AddingTariffComponent', () => {
  let component: AddAndChangeTariffComponent;
  let fixture: ComponentFixture<AddAndChangeTariffComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAndChangeTariffComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAndChangeTariffComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
