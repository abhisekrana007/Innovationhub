import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpertprofileComponent } from './expertprofile.component';

describe('ExpertprofileComponent', () => {
  let component: ExpertprofileComponent;
  let fixture: ComponentFixture<ExpertprofileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExpertprofileComponent]
    });
    fixture = TestBed.createComponent(ExpertprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
