import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { authenticateExpertGuard } from './authenticate-expert.guard';

describe('authenticateExpertGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => authenticateExpertGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
