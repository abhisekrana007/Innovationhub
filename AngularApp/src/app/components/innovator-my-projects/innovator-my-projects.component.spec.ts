import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InnovatorMyProjectsComponent } from './innovator-my-projects.component';

describe('InnovatorMyProjectsComponent', () => {
  let component: InnovatorMyProjectsComponent;
  let fixture: ComponentFixture<InnovatorMyProjectsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InnovatorMyProjectsComponent]
    });
    fixture = TestBed.createComponent(InnovatorMyProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
