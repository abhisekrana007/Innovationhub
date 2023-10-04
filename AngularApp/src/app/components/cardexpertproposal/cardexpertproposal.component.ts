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
  proposalComment!:string;
  proposalId!:string;
  expertId!:string;
  projectId!:string;
  //projectID:string=""

  submitted : boolean = false;


  constructor(private fb : FormBuilder,private _proposalService: ProposalserviceService,private _projectService:ProjectserviceService) {
    this.UpdateForm= fb.group({
      proposalComment: new FormControl("", [Validators.required]),
      proposalId: new FormControl(''),
      expertId:new FormControl(''),
      projectId:new FormControl('')
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

  propid: any ="";
  projid:any="";
  expid:any="";
  //---------------------------------------------------------------------------------- 
  //CALLING A PROJECT FOR PROJECTDETAIS BY PROJECTID WHICH I WILL GET BY CLICK EVENT
  onClick(pid:string,proid:any,exid:any)
  {
    console.log(pid);
    console.log(proid);
    this.propid=proid;
    this.projid=pid;
    this.expid=exid;

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
  
  propsalUpdated(regForm : any)
  {
   alert("are you sure you want to edit your proposal")
    this.submitted = true;
    if(this.UpdateForm.invalid) return;
    else{
      var user=regForm.value;
      user.proposalId=this.propid;
      user.projectId=this.projid;
      user.expertId=this.expid; 
      //user.projectID=this.projectID;
       //user.expertId=this._jwt.getUserId();
      console.log("VAlid" + JSON.stringify(user))
      this._proposalService.updatesProposal(user,this.propid).subscribe(res=>
        {
        console.log(res)
        //this.getExpertProposals();
        })

 

    }
    console.log(this.UpdateForm.value);
    setTimeout(function(){
      location.reload();
    }, 2000);
    // window.location.reload(); 

 

  }

//---------------------------------------------------------------------------------------------

//Deleting Proposal by proposal id

proposalDeleted(){

  alert("are you sure you want to delete the proposal");
 
this._proposalService.deleteProposal(this.propid).subscribe();
setTimeout(function(){
          location.reload();
        }, 2000);
// window.location.reload(); 
   

}
  
  
   


}
