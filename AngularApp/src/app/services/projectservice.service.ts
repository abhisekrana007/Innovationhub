import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Project } from 'src/models/project';
import { DecodeJWTService } from './decode-jwt.service';

@Injectable({
  providedIn: 'root'
})
export class ProjectserviceService {

  

constructor(private _http:  HttpClient,private _jwt:DecodeJWTService) { }

  url:string="https://localhost:7117/api/Project"
  

 

 

  getAllProjects(): Observable<Project[]> {

    return this._http.get<Project[]>(this.url);

  }
  
  getInnovatorProjects(): Observable<Project[]> {
    console.log(this._jwt.getUserId());
    return this._http.get<Project[]>(this.url+"/GetByInnovatorId/"+this._jwt.getUserId());
  }
  //-----------------------------------------------------------------------------------------
  //GET PROJECT BY PROJECT ID 
  //
  getProjectByProjectid(id:string):Observable<Project>{
      return this._http.get<Project>(this.url+"/projects/"+id);   
  }
//------------------------------------------------------------------------------------------
 

 

  AddProject(project : Project) : Observable<Project>

  {

    console.log("USER INS SRECIVCE " + JSON.stringify(project));

 

  return this._http.post<Project>(this.url, JSON.stringify(project),

  {

    headers: new HttpHeaders({

    'Content-Type':'application/json',

    'Accept' :'application/json'

  })

  }

  )

}




}
