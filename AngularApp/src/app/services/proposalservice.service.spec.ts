import { TestBed } from '@angular/core/testing';

import { ProposalserviceService } from './proposalservice.service';

describe('ProposalserviceService', () => {
  let service: ProposalserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProposalserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
