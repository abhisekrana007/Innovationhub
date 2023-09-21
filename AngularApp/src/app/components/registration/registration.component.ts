import { Component } from '@angular/core';
import { RegistrationService } from 'src/app/services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  innovator: any = {};
  expert: any = {};

  constructor(private registrationService: RegistrationService) {}

  registerInnovator() {
    //  RegistrationService to handle HTTP requests
    this.registrationService.registerInnovator(this.innovator).subscribe(
      (response) => {
        console.log('Innovator registered:', response);
        // Clear form fields or perform other actions after successful registration
      },
      (error) => {
        console.error('Error registering Innovator:', error);
        // Handle registration error (e.g., display an error message)
      }
    );
  }

  registerExpert() {
    //  RegistrationService to handle HTTP requests
    this.registrationService.registerExpert(this.expert).subscribe(
      (response) => {
        console.log('Expert registered:', response);
        // Clear form fields or perform other actions after successful registration
      },
      (error) => {
        console.error('Error registering Expert:', error);
        // Handle registration error (e.g., display an error message)
      }
    );
  }
}


