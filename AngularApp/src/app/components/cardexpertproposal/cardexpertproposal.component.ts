import { Component } from '@angular/core';
import { ProposalserviceService } from 'src/app/services/proposalservice.service';
import { Proposal } from 'src/models/proposal';

@Component({
  selector: 'app-cardexpertproposal',
  templateUrl: './cardexpertproposal.component.html',
  styleUrls: ['./cardexpertproposal.component.css']
})
export class CardexpertproposalComponent {

  proposals:Proposal[]=[]

 

  constructor(private _proposalService: ProposalserviceService) {}
  
   
  
  ngOnInit() {
    this.getAllProposals();
  }
  
   
  
  getAllProposals() {
    this._proposalService.getAllProposals().subscribe((data: Proposal[]) => {
      this.proposals = data;
      console.log(this.proposals);
    });
  }
  
   


}
