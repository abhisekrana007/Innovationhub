import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  


    private apiUrl = 'https://localhost:7285/api/v1';   
        constructor(private http: HttpClient) { }
  
    registerInnovator(innovatorData: any) {
      return this.http.post(`${this.apiUrl}/Innovator`, innovatorData);
    }
  
    registerExpert(expertData: any) {
      return this.http.post(`${this.apiUrl}/Expert`, expertData);
    }
  }
