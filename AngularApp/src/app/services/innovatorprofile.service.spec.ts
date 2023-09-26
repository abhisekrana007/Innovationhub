import { TestBed } from '@angular/core/testing';

import { InnovatorprofileService } from './innovatorprofile.service';

describe('InnovatorprofileService', () => {
  let service: InnovatorprofileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InnovatorprofileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
