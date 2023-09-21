import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/models/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private innovatorUrl = 'https://localhost:7285/api/Authentication/innovator/login';
  private expertUrl = 'url';
  
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

  authenticateExpert(user : User) : Observable<string>{
    return this._http.post<string>(this.expertUrl,
    JSON.stringify(user),
    {
      headers: new HttpHeaders({
        'Content-Type':'application/json',
        'Accept':'application/json'
      })
    });
}

  setBearerToken (token : string){
    localStorage.clear();
    localStorage.setItem("bearerToken", token );
  }  
}
