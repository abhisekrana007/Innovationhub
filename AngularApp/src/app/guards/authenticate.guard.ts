import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { inject } from '@angular/core';
import { RoutingService } from '../services/routing.service';
export const authenticateGuard: CanActivateFn = (route, state) => {
  const auth = inject(LoginService)
  const route1 = inject (RoutingService)
  if(auth.getBearerToken() != null)
    return true;
  else
  {
    route1.toLogin();
    return false;
  }
};
