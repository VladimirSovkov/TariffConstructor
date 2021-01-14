import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAndChangeTermsOfUseComponent } from './add-and-change-terms-of-use.component';

describe('AddAndChangeTermsOfUseComponent', () => {
  let component: AddAndChangeTermsOfUseComponent;
  let fixture: ComponentFixture<AddAndChangeTermsOfUseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAndChangeTermsOfUseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAndChangeTermsOfUseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
