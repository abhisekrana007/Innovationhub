import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InnovatorprojecthomeComponent } from './innovatorprojecthome.component';

describe('InnovatorprojecthomeComponent', () => {
  let component: InnovatorprojecthomeComponent;
  let fixture: ComponentFixture<InnovatorprojecthomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InnovatorprojecthomeComponent]
    });
    fixture = TestBed.createComponent(InnovatorprojecthomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
