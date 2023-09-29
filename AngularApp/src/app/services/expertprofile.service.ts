import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Expert } from 'src/models/expert';
import { Project } from 'src/models/project';

@Injectable({
  providedIn: 'root',
})
export class ExpertprofileService  {
  private url = 'https://localhost:7285/api/v1/Expert'; // Replace with your actual API URL

 

  constructor(private http: HttpClient) {}

  // Fetch user profile data from the server
  getUserProfile(userId: number): Observable<Expert> {
    const url = `${this.url}/${userId}`;
    return this.http.get<Expert>(url);
  }

  getExpertByExpertId(project : Project){
    return this.http.get<Expert>(this.url+"/"+project.expertId);
  }

  // Update user profile data on the server
  updateUserProfile(userId: number, updatedProfile: Expert): Observable<Expert> {
    const url = `${this.url}/${userId}`;
    return this.http.put<Expert>(url, updatedProfile);
  }
}

