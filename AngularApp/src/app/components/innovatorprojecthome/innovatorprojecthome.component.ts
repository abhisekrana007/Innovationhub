import { Component } from '@angular/core';
import {FormControl, FormGroup, FormBuilder, Validators} from '@angular/forms';
import { ProjectserviceService } from 'src/app/services/projectservice.service';
@Component({
  selector: 'app-innovatorprojecthome',
  templateUrl: './innovatorprojecthome.component.html',
  styleUrls: ['./innovatorprojecthome.component.css']
})
export class InnovatorprojecthomeComponent {


  ProjectForm :  FormGroup;
  projectTitle:string=""
  ProjectDoc:string=""
  description:string=""
  RequiredSkills:string=""

 

  submitted : boolean = false;

 

  constructor(private fb : FormBuilder, private _projectService : ProjectserviceService)
  {
this.ProjectForm= fb.group({
   projectTitle: new FormControl("", [Validators.required]),
   ProjectDoc: new FormControl("", [Validators.required]),
   description:new FormControl("", [Validators.required]),
   RequiredSkills:new FormControl("",[Validators.required])
})     
}

 

projectSubmitted(regForm : any)
  {
    this.submitted = true;
    if(this.ProjectForm.invalid) return;
    else{
      var user=regForm.value;
      console.log("VAlid" + JSON.stringify(user))
      this._projectService.AddProject(user).subscribe(res=>
        {
        console.log(res)
        })

 

    }
    console.log(this.ProjectForm.value);

 

  }

 

}
