import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/models/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  // private innovatorUrl = 'https://innovatorshub.azure-api.net/myapi/api/v1/authentication/Innovator/login';
  private innovatorUrl = 'https://authservice-team1.azurewebsites.net/api/v1/authentication/innovator/login';
  // private expertUrl = 'https://innovatorshub.azure-api.net/myapi/api/v1/authentication/Expert/login';
  private expertUrl = 'https://authservice-team1.azurewebsites.net/api/v1/authentication/expert/login';
  
  constructor(private _http: HttpClient) { }
  
  authenticateInnovator(user : any) : Observable<string>{
    console.log(user);
      return this._http.post<string>(this.innovatorUrl, user,
      {
        headers: new HttpHeaders({
          'Content-Type':'application/json',
          'Accept':'application/json'
        })
      });
  }

  authenticateExpert(user : any) : Observable<string>{
    return this._http.post<string>(this.expertUrl, user,
    {
      headers: new HttpHeaders({
        'Content-Type':'application/json',
        'Accept':'application/json'
      })
    });
  }
  getBearerToken(){    
    return localStorage.getItem("bearerToken");
  }

  setBearerToken (token : string){
    localStorage.clear();
    localStorage.setItem("bearerToken", token );
  }  
}
