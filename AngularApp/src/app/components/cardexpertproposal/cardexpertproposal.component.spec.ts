import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardexpertproposalComponent } from './cardexpertproposal.component';

describe('CardexpertproposalComponent', () => {
  let component: CardexpertproposalComponent;
  let fixture: ComponentFixture<CardexpertproposalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CardexpertproposalComponent]
    });
    fixture = TestBed.createComponent(CardexpertproposalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
