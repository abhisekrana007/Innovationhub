import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

    // private apiUrl = 'https://innovatorshub.azure-api.net/myapi/api/v1';
    private apiUrl = 'https://localhost:7272';
        constructor(private http: HttpClient) { }
  
    registerInnovator(innovatorData: any) {
      return this.http.post(`${this.apiUrl}/innovator`, innovatorData);
    }
  
    registerExpert(expertData: any) {
      return this.http.post(`${this.apiUrl}/expert`, expertData);
    }
  }
