import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardinovhomeComponent } from './cardinovhome.component';

describe('CardinovhomeComponent', () => {
  let component: CardinovhomeComponent;
  let fixture: ComponentFixture<CardinovhomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CardinovhomeComponent]
    });
    fixture = TestBed.createComponent(CardinovhomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
