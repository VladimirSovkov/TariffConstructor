import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAndChangeApplicationComponent } from './add-and-change-application.component';

describe('AddAndChangeApplicationComponent', () => {
  let component: AddAndChangeApplicationComponent;
  let fixture: ComponentFixture<AddAndChangeApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAndChangeApplicationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAndChangeApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
