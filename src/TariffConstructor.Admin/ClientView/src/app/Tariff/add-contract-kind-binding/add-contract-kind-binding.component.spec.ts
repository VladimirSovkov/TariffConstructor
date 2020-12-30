import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddContractKindBindingComponent } from './add-contract-kind-binding.component';

describe('AddContractKindBindingComponent', () => {
  let component: AddContractKindBindingComponent;
  let fixture: ComponentFixture<AddContractKindBindingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddContractKindBindingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddContractKindBindingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
