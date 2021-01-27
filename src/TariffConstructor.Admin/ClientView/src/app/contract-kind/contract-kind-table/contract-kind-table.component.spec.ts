import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractKindTableComponent } from './contract-kind-table.component';

describe('ContractKindTableComponent', () => {
  let component: ContractKindTableComponent;
  let fixture: ComponentFixture<ContractKindTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContractKindTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContractKindTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
