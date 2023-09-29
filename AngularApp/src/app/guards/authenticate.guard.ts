import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { inject } from '@angular/core';
import { RoutingService } from '../services/routing.service';
import { DecodeJWTService } from '../services/decode-jwt.service';
export const authenticateGuard: CanActivateFn = (route, state) => {
  const auth = inject(DecodeJWTService)
  const route1 = inject (RoutingService)
  const allowedRoles = ["Innovator", "Expert"];
  var check = auth.getRole();

  if (check!=null && allowedRoles.includes(check)) {
    return true;
  } else {
    route1.toLogin();
    return false;
  }
  // console.log(auth.getRole());
  // if(auth.getRole() == "Innovator")
  //   return true;
  // else
  // {
  //   route1.toLogin();
  //   return false;
  // }
};
