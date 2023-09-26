import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import { Project } from 'src/models/project';


 

@Injectable({
  providedIn: 'root'
})
export class CardService {

  

  constructor(private http: HttpClient) { }

  get(id : string){
    return this.http.get<Project>("https://localhost:7117/api/Project/GetbyInnoid/"+id)
    .pipe(map((res:any)=>{
      return res;
    }))
  }
}
