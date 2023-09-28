import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { lastValueFrom, throwError } from 'rxjs';
import { DecodeJWTService } from 'src/app/services/decode-jwt.service';
import { LoginService } from 'src/app/services/login.service';
import { RoutingService } from 'src/app/services/routing.service';
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

  constructor(private fb : FormBuilder,private _loginservice: LoginService,private _decodejwtservice: DecodeJWTService,private _routingservice : RoutingService) {
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
          this._loginservice.setBearerToken(this.token.token);      
          this._routingservice.toInnovatorMain();
        } catch (err) {
          this.handleError(err);
        }             
      
      
      // var userid = this._decodejwtservice.getUserId();
      // console.log(userid);
      
                 
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
      console.log("hello");
      this._loginservice.authenticateExpert(user).subscribe(
        ((res) =>this.token = (res)),
        (err:any)=>{        
          this.handleError(err);
        }) 
        try {
          this.token = await lastValueFrom(this._loginservice.authenticateExpert(user));
          this._loginservice.setBearerToken(this.token.token);      
          this._routingservice.toExpertMain();
        } catch (err) {
          this.handleError(err);
        }             
      
      
                 
    }      
  }

  handleError(err: any)
  {
    alert("Invalid Email or/and Password");
  };

}
