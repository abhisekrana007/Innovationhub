import { Component } from '@angular/core';
import { FormBuilder,FormControl, FormGroup, Validators } from '@angular/forms';
import { ProjectserviceService } from 'src/app/services/projectservice.service';
import { ProposalserviceService } from 'src/app/services/proposalservice.service';
import { Project } from 'src/models/project';
import { Proposal } from 'src/models/proposal';

@Component({
  selector: 'app-cardexpertproposal',
  templateUrl: './cardexpertproposal.component.html',
  styleUrls: ['./cardexpertproposal.component.css']
})
export class CardexpertproposalComponent {

  proposals:Proposal[]=[];
  project:Project=new Project();

  UpdateForm :  FormGroup;
  proposalComment:string="";
  //projectID:string=""

  submitted : boolean = false;


  constructor(private fb : FormBuilder,private _proposalService: ProposalserviceService,private _projectService:ProjectserviceService) {
    this.UpdateForm= fb.group({
      proposalComment: new FormControl("comment", [Validators.required])
      //projectID: new FormControl(this.id, [Validators.required])
       // ProjectId: new FormControl("", [Validators.required]),
       // ExpertId:new FormControl("",[Validators.required])
   }) 
  }
  
   
  
  ngOnInit() {
    this.getExpertProposals();
  }
  
   
  getExpertProposals() {
    this._proposalService.getExpertProposals().subscribe((data: Proposal[]) => {
      this.proposals = data;
      console.log(this.proposals);
    });
  }

  //---------------------------------------------------------------------------------- 
  //CALLING A PROJECT FOR PROJECTDETAIS BY PROJECTID WHICH I WILL GET BY CLICK EVENT
  onClick(pid:string)
  {
    console.log(pid);
         this.getProjectByProjectId(pid)
  }
  getProjectByProjectId(pid:string) {
    this._projectService.getProjectByProjectid(pid).subscribe((data:Project) => {
      this.project = data;
      console.log(this.project);
    });
  }
//------------------------------------------------------------------------------------


  
  //-----------------------------------------------------------------------------------
  //updating proposal 
  
  //propsalUpdated(regForm : any,pid:string)
 // {
   // alert(regForm.value)
    //this.submitted = true;
    //if(this.ProposalForm.invalid) return;
    //else{
      //var user=regForm.value;

      //console.log("VAlid" + JSON.stringify(user))
   //this._proposalService.updatePropsal(user,pid).subscribe(response => {
      // Handle the response here
      //console.log('PUT request successful', response);
    //}, error => {
      // Handle any errors here
     // console.error('Error making PUT request', error);
    //});

   //          
  //}
//---------------------------------------------------------------------------------------------

//Deleting Proposal by proposal id

//proposalDeleted(pid:string){
 
//this._proposalService.deleteProposal(pid).subscribe(response => {
      // Handle the response here
     // console.log('DELETE request successful', response);
    //}, error => {
      // Handle any errors here
      //console.error('Error making DELETE request', error);
    //});
   

//}
  
  
   


}
