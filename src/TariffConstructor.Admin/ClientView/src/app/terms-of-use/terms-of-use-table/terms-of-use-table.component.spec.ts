import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TermsOfUseTableComponent } from './terms-of-use-table.component';

describe('TermsOfUseTableComponent', () => {
  let component: TermsOfUseTableComponent;
  let fixture: ComponentFixture<TermsOfUseTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TermsOfUseTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TermsOfUseTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
