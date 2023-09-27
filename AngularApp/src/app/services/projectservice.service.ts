import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Project } from 'src/models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectserviceService {

  

constructor(private _http:  HttpClient) { }

  url:string="https://localhost:7117/api/project"
  

 

 

  getAllProjects(): Observable<Project[]> {

    return this._http.get<Project[]>(this.url);

  }
  
  //-----------------------------------------------------------------------------------------
  //GET PROJECT BY PROJECT ID 
  //
  //getPropojectByProjectid(id):Observable<Project>{
  //    return this._http.get<Project>(this.url+"/GetById"+id);   
  //}
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