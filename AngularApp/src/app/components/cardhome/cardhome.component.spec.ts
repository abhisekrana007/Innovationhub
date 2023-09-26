import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardhomeComponent } from './cardhome.component';

describe('CardhomeComponent', () => {
  let component: CardhomeComponent;
  let fixture: ComponentFixture<CardhomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CardhomeComponent]
    });
    fixture = TestBed.createComponent(CardhomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
