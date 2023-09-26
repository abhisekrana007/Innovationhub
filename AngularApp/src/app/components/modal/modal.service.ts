import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import { Project } from 'src/models/project';


@Injectable({
  providedIn: 'root'
})
export class ModalService {

  constructor(private http: HttpClient) { }


  update(data :any,id:number){
    return this.http.put<Project>("https://localhost:7117/api/Project/"+id,data)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
  
  delete(id : number){
    return this.http.delete<Project>("https://localhost:7117/api/Project/"+id)
    .pipe(map((res:any)=>{
      return res;
    }
    ))
  }

  get(id : string){
    return this.http.get<Project>("https://localhost:7117/api/Project/GetbyInnoid/"+id)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
}
