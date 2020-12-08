import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeTariffComponent } from './change-tariff.component';

describe('ChangeTariffComponent', () => {
  let component: ChangeTariffComponent;
  let fixture: ComponentFixture<ChangeTariffComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangeTariffComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangeTariffComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
