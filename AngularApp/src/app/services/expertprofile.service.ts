import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Expert } from 'src/models/expert';

@Injectable({
  providedIn: 'root',
})
export class ExpertprofileService  {
  private apiUrl = 'your_backend_api_url'; // Replace with your actual API URL

 

  constructor(private http: HttpClient) {}

  // Fetch user profile data from the server
  getUserProfile(userId: number): Observable<Expert> {
    const url = `${this.apiUrl}/${userId}`;
    return this.http.get<Expert>(url);
  }

  // Update user profile data on the server
  updateUserProfile(userId: number, updatedProfile: Expert): Observable<Expert> {
    const url = `${this.apiUrl}/${userId}`;
    return this.http.put<Expert>(url, updatedProfile);
  }
}

