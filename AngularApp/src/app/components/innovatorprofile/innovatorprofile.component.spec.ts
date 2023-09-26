import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InnovatorprofileComponent } from './innovatorprofile.component';

describe('InnovatorprofileComponent', () => {
  let component: InnovatorprofileComponent;
  let fixture: ComponentFixture<InnovatorprofileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InnovatorprofileComponent]
    });
    fixture = TestBed.createComponent(InnovatorprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
