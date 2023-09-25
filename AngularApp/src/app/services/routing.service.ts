import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RoutingService {

  constructor(private _route : Router) { }

  toLogin()
  {
    this._route.navigate(["login"]);
  }

  

}

