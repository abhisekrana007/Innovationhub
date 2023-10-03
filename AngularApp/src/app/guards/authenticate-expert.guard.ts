import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { inject } from '@angular/core';
import { RoutingService } from '../services/routing.service';
import { DecodeJWTService } from '../services/decode-jwt.service';
export const authenticateExpertGuard: CanActivateFn = (route, state) => {
  const auth = inject(DecodeJWTService)
  const route1 = inject (RoutingService)
  console.log(auth.getRole());
  if(auth.getRole() == "Expert"){
    console.log(auth.getRole());
    return true;
  }
  else
  {
    route1.toLogin();
    return false;
  }
};
