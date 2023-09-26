import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { lastValueFrom, throwError } from 'rxjs';
import { LoginService } from 'src/app/services/login.service';
import { User } from 'src/models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginInnovatorForm :  FormGroup;
  loginExpertForm :  FormGroup;
  innovator: any = {};
  expert: any = {};
  token : any = {};

  constructor(private fb : FormBuilder,private _loginservice: LoginService) {
    this.loginInnovatorForm= fb.group({
      Email : new FormControl("", [Validators.required,Validators.email]),
      Password: new FormControl("",[Validators.required,Validators.minLength(3)])
    })
    this.loginExpertForm= fb.group({
      Email : new FormControl("", [Validators.required,Validators.email]),
      Password: new FormControl("",[Validators.required,Validators.minLength(3)])
    })
  }

  async loginInnovator(regForm: any)
  {
    
    if(this.loginInnovatorForm.invalid) return;
    else{
      var user = {
        "Email" : regForm.controls.Email.value,
        "Password" : regForm.controls.Password.value  
      }; 
      console.log(user);      
      this._loginservice.authenticateInnovator(user).subscribe(
        ((res) =>this.token = (res)),
        (err:any)=>{        
          this.handleError(err);
        }) 
        try {
          this.token = await lastValueFrom(this._loginservice.authenticateInnovator(user));          
        } catch (err) {
          throwError;
        }             
      
      this._loginservice.setBearerToken(this.token.token);
      //this._routerservice.routeToDashboard();
                 
    }      
  }

  async loginExpert(regForm: any)
  {
    if(this.loginExpertForm.invalid) return;
    else{
      var user = {
        "Email" : regForm.controls.Email.value,
        "Password" : regForm.controls.Password.value  
      };    
      console.log(user);
      this._loginservice.authenticateExpert(user).subscribe(
        ((res) =>this.token = (res)),
        (err:any)=>{        
          this.handleError(err);
        }) 
        try {
          this.token = await lastValueFrom(this._loginservice.authenticateExpert(user));
        } catch (err) {
          throwError;
        }             
      
      this._loginservice.setBearerToken(this.token.token);
      //this._routerservice.routeToDashboard();
                 
    }      
  }

  handleError(err: any)
  {
    alert(err.message);
  };

}
