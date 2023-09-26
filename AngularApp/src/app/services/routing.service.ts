import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RoutingService {

  constructor(private _route : Router) { }

  toRegister(){
    this._route.navigate(["registration"]);
  }
  
  toLogin()
  {
    this._route.navigate(["login"]);
  }

  toInnovatorMain(){
    this._route.navigate(["innovator/home"])
  }

  toExpertMain(){
    this._route.navigate(["expert/home"])
  }

  

}

