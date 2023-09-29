import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class DecodeJWTService {

  constructor() { }

  jwtToken: any = localStorage.getItem("bearerToken");
  decodedToken: { [key: string]: string } = {};

  decodeToken() {
    if (this.jwtToken) {
      this.decodedToken = jwt_decode(this.jwtToken);
    }
  }

  getUserId() {
    this.decodeToken();
    return this.decodedToken ? this.decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] : null;
  }

  getRole(){
    this.decodeToken();
    return this.decodedToken ? this.decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] : null;
  }
}
