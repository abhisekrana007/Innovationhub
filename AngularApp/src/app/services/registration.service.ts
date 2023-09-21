import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  


    private apiUrl = 'YOUR_API_URL';   
    constructor(private http: HttpClient) { }
  
    registerInnovator(innovatorData: any) {
      return this.http.post(`${this.apiUrl}/innovators`, innovatorData);
    }
  
    registerExpert(expertData: any) {
      return this.http.post(`${this.apiUrl}/experts`, expertData);
    }
  }
