import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DecodeJWTService } from 'src/app/services/decode-jwt.service';
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
  //projects1:Project[]=[]
  // id:string="";



  ProposalForm :  FormGroup;
  proposalComment!:string;
  projectID!:string;
  expertid!:string;

 

  submitted : boolean = false;



constructor(private fb : FormBuilder, private _proposalService : ProposalserviceService,private _projectService: ProjectserviceService,private _jwt:DecodeJWTService) {
  this.ProposalForm= fb.group({
    proposalComment: new FormControl("comment", [Validators.required]),
    projectID: new FormControl(''),
    expertid:new FormControl('')
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
  // console.log(id);
  // alert(id);
   
}

onClick1(id:any){
  // console.log(id);
  //alert(id);
  this.projectID = id;
  // this.projectID = id; 
  this.getProjectById(id);
}

project1: any ="";
getProjectById(id : string)
{
this.project1 = this.projects.filter(x=>x.projectID== id);
//alert(JSON.stringify(this.project1));
console.log(this.project1);
}
 
getProjects() {
  this._projectService.getAllProjects().subscribe((data: Project[]) => {
    this.projects = data;
   // this.projects1=data;
  
    console.log(this.projects);
  });
}
// proposalkSubmitted

proposalSubmitted(regForm : any)
  {
  //  alert(regForm.value)
    this.submitted = true;
    if(this.ProposalForm.invalid) return;
    else{
      var user=regForm.value;
       user.projectID=this.projectID;
       user.expertId=this._jwt.getUserId();
      console.log("VAlid" + JSON.stringify(user))
      this._proposalService.AddProposal(user).subscribe(res=>
        {
        console.log(res)
        })

 

    }

    console.log(this.ProposalForm.value);
    window.location.reload();  
 

  }

  
  get proposalcomment():FormControl{
    return this.ProposalForm.get("proposalComment") as FormControl;
  }  
  



}
