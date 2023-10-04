import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Proposal } from 'src/models/proposal';
import { DecodeJWTService } from './decode-jwt.service';
import { Project } from 'src/models/project';

@Injectable({
  providedIn: 'root'
})
export class ProposalserviceService {

  constructor(private _http:  HttpClient,private _jwt:DecodeJWTService ) { }
  // url:string="https://innovatorshub.azure-api.net/myproject/api/Proposal";
  url:string="https://localhost:7272/proposal"

  AddProposal(proposal : Proposal) : Observable<Proposal>
  {
    console.log("USER INS SRECIVCE " + JSON.stringify(proposal));

 

  return this._http.post<Proposal>(this.url, JSON.stringify(proposal),
  {
    headers: new HttpHeaders({
    'Content-Type':'application/json',
    'Accept' :'application/json'
  })
  }
  )
}

 

getAllProposals(): Observable<Proposal[]> {
  return this._http.get<Proposal[]>(this.url);
}
getExpertProposals(): Observable<Proposal[]> {
  console.log(this._jwt.getUserId());
  return this._http.get<Proposal[]>(this.url+"/experts/"+this._jwt.getUserId());
}
getProposalsByProjectId(project: Project): Observable<Proposal[]>{
  return this._http.get<Proposal[]>(this.url+"/project/"+project.projectID);
}


//---------------------------------------------------------------------------------
//UPDATE PROPOSAL API CALL
updatePropsalStatus(proposalid :any) : Observable<Proposal>{
  console.log(this.url+"/update/"+proposalid+"?status=Running");
  return this._http.put<Proposal>(this.url+"/update/"+proposalid+"?status=Running","Running");
}
updatesProposal(proposal:Proposal,proposalid:any):Observable<Proposal>{
  return this._http.put<Proposal>(this.url+"/"+proposalid,JSON.stringify(proposal),
  {
    headers: new HttpHeaders({
    'Content-Type':'application/json',
    'Accept' :'application/json'
  })
  });
}
//------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------
//Delete Proposal
deleteProposal(proposalid:any):Observable<Proposal>{
  return this._http.delete<Proposal>(this.url+"/"+proposalid);
}
 
}
