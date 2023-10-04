import { Component } from '@angular/core';
import {FormControl, FormGroup, FormBuilder, Validators} from '@angular/forms';
import { DecodeJWTService } from 'src/app/services/decode-jwt.service';
import { ProjectserviceService } from 'src/app/services/projectservice.service';
@Component({
  selector: 'app-innovatorprojecthome',
  templateUrl: './innovatorprojecthome.component.html',
  styleUrls: ['./innovatorprojecthome.component.css']
})
export class InnovatorprojecthomeComponent {


  ProjectForm :  FormGroup;
  projectTitle!:string;
  description!:string;
  requiredSkills!:string;
  innovatorID!:string;

 

  submitted : boolean = false;

 

  constructor(private fb : FormBuilder, private _projectService : ProjectserviceService,private _jwt:DecodeJWTService)
  {
this.ProjectForm= fb.group({
   projectTitle: new FormControl("", [Validators.required]),
  // ProjectDoc: new FormControl("", [Validators.required]),
   description:new FormControl("", [Validators.required]),
   requiredSkills:new FormControl("",[Validators.required]),
   innovatorID: new FormControl('')
})     
}

 

projectSubmitted(regForm : any)
  {
    this.submitted = true;
    if(this.ProjectForm.invalid) return;
    else{
      var user=regForm.value;
      user.innovatorID=this._jwt.getUserId();
      console.log("VAlid" + JSON.stringify(user))
      this._projectService.AddProject(user).subscribe(res=>
        {
        console.log(res)
        })
        setTimeout(function(){
          location.reload();
        }, 2000);
        // window.location.reload();

 

    }
    console.log(this.ProjectForm.value);

 

  }

 

}
