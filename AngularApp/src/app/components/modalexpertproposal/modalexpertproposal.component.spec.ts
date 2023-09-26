import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalexpertproposalComponent } from './modalexpertproposal.component';

describe('ModalexpertproposalComponent', () => {
  let component: ModalexpertproposalComponent;
  let fixture: ComponentFixture<ModalexpertproposalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalexpertproposalComponent]
    });
    fixture = TestBed.createComponent(ModalexpertproposalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
