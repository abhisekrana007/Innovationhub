import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ProjectserviceService } from 'src/app/services/projectservice.service';
import { ProposalserviceService } from 'src/app/services/proposalservice.service';
import { Project } from 'src/models/project';

@Component({
  selector: 'app-cardhome',
  templateUrl: './cardhome.component.html',
  styleUrls: ['./cardhome.component.css']
})
export class CardhomeComponent {

  projects:Project[]=[]
  
  // id:string="";



  ProposalForm :  FormGroup;
  proposalComment!:string;
  projectID!:string;


 

  submitted : boolean = false;



constructor(private fb : FormBuilder, private _proposalService : ProposalserviceService,private _projectService: ProjectserviceService) {
  this.ProposalForm= fb.group({
    proposalComment: new FormControl("comment", [Validators.required]),
    projectID: new FormControl('', [Validators.required])
     // ProjectId: new FormControl("", [Validators.required]),
     // ExpertId:new FormControl("",[Validators.required])
 })  
}

 

ngOnInit() {
  this.getProjects();
  //this.projectID = this.tempId;
}

tempId :any;
onClick(id:any){
  console.log(id);
  this.projectID = id; 
}

 
getProjects() {
  this._projectService.getAllProjects().subscribe((data: Project[]) => {
    this.projects = data;
  
    console.log(this.projects);
  });
}
// proposalkSubmitted

proposalSubmitted(regForm : any)
  {
    alert(regForm.value)
    this.submitted = true;
    if(this.ProposalForm.invalid) return;
    else{
      var user=regForm.value;
       user.projectID=this.projectID
      console.log("VAlid" + JSON.stringify(user))
      this._proposalService.AddProposal(user).subscribe(res=>
        {
        console.log(res)
        })

 

    }
    console.log(this.ProposalForm.value);

 

  }
  get proposalcomment():FormControl{
    return this.ProposalForm.get("proposalComment") as FormControl;
  }  
  



}
