import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Innovator } from 'src/models/innovator';

@Injectable({
  providedIn: 'root',
})
export class InnovatorprofileService {
  private apiUrl = 'your_backend_api_url'; // Replace with your actual API URL



  constructor(private http: HttpClient) {}

  // Fetch user profile data from the server
  getUserProfile(userId: number): Observable<Innovator> {
    const url = `${this.apiUrl}/${userId}`;
    return this.http.get<Innovator>(url);
  }

  // Update user profile data on the server
  updateUserProfile(userId: number, updatedProfile: Innovator): Observable<Innovator> {
    const url = `${this.apiUrl}/${userId}`;
    return this.http.put<Innovator>(url, updatedProfile);
  }
}

