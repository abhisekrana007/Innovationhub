import { TestBed } from '@angular/core/testing';

import { ExpertprofileService } from './expertprofile.service';

describe('ExpertprofileService', () => {
  let service: ExpertprofileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExpertprofileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
