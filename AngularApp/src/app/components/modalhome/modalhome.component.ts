import { Component } from '@angular/core';
import {FormControl, FormGroup, FormBuilder, Validators} from '@angular/forms';
import { ProjectserviceService } from 'src/app/services/projectservice.service';
import { ProposalserviceService } from 'src/app/services/proposalservice.service';
@Component({
  selector: 'app-modalhome',
  templateUrl: './modalhome.component.html',
  styleUrls: ['./modalhome.component.css']
})
export class ModalhomeComponent {
       
  ProposalForm :  FormGroup;
  ProposalComment:string=""
  //ProposalDocument:string=""


 

  submitted : boolean = false;

 

  constructor(private fb : FormBuilder, private _proposalService : ProposalserviceService)
  {
this.ProposalForm= fb.group({
   ProposalComment: new FormControl("comment", [Validators.required])
    // ProjectId: new FormControl("", [Validators.required]),
    // ExpertId:new FormControl("",[Validators.required])
})     
}

 

proposalSubmitted(regForm : any)
  {
    this.submitted = true;
    if(this.ProposalForm.invalid) return;
    else{
      var user=regForm.value;

      console.log("VAlid" + JSON.stringify(user))
      this._proposalService.AddProposal(user).subscribe(res=>
        {
        console.log(res)
        })

 

    }
    console.log(this.ProposalForm.value);

 

  }

 

get proposalcomment():FormControl{
  return this.ProposalForm.get("ProposalComment") as FormControl;
}  



}
