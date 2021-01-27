import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAndChangeContractKindComponent } from './add-and-change-contract-kind.component';

describe('AddAndChangeContractKindComponent', () => {
  let component: AddAndChangeContractKindComponent;
  let fixture: ComponentFixture<AddAndChangeContractKindComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAndChangeContractKindComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAndChangeContractKindComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
