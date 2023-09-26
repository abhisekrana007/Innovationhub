import { CanActivateFn, Router } from '@angular/router';
import { AuthenticateService } from '../services/authenticate.service';
import { inject } from '@angular/core';
import { RoutingService } from '../services/routing.service';
export const authenticateGuard: CanActivateFn = (route, state) => {
  const auth = inject(AuthenticateService)
  const route1 = inject (RoutingService)
if(auth.GetValueFromLocalStorage() == true)
  return true;
  else 
  {
   route1.toLogin();
   return false;
  }
  // return false;
  };
