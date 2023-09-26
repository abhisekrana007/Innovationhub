import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalinovhomeComponent } from './modalinovhome.component';

describe('ModalinovhomeComponent', () => {
  let component: ModalinovhomeComponent;
  let fixture: ComponentFixture<ModalinovhomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalinovhomeComponent]
    });
    fixture = TestBed.createComponent(ModalinovhomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
