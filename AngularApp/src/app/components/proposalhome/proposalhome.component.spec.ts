import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProposalhomeComponent } from './proposalhome.component';

describe('ProposalhomeComponent', () => {
  let component: ProposalhomeComponent;
  let fixture: ComponentFixture<ProposalhomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProposalhomeComponent]
    });
    fixture = TestBed.createComponent(ProposalhomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
