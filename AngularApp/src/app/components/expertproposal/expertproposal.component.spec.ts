import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpertproposalComponent } from './expertproposal.component';

describe('ExpertproposalComponent', () => {
  let component: ExpertproposalComponent;
  let fixture: ComponentFixture<ExpertproposalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExpertproposalComponent]
    });
    fixture = TestBed.createComponent(ExpertproposalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
