import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Proposal } from 'src/models/proposal';
import { DecodeJWTService } from './decode-jwt.service';

@Injectable({
  providedIn: 'root'
})
export class ProposalserviceService {

  constructor(private _http:  HttpClient,private _jwt:DecodeJWTService ) { }
  url:string="https://localhost:7117/api/proposal";

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


//---------------------------------------------------------------------------------
//UPDATE PROPOSAL API CALL
//updatePropsal(propsal:Proposal,string proposalid):: Observable<Proposal>{


   // return this.http.put(url+"/UpdateProposal"+proposalid, newData);

//}
//------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------
//Delete Proposal
//deleteProposal(string: proposalid):Observable<Proposal>{
 // return this.http.delete(url+"/DeleteProposal"+proposalid);
//}
 
}
