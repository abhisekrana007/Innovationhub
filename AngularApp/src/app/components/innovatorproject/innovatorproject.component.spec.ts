import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InnovatorprojectComponent } from './innovatorproject.component';

describe('InnovatorprojectComponent', () => {
  let component: InnovatorprojectComponent;
  let fixture: ComponentFixture<InnovatorprojectComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InnovatorprojectComponent]
    });
    fixture = TestBed.createComponent(InnovatorprojectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
