import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegistrationService } from 'src/app/services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})

export class RegistrationComponent {
  innovatorForm: FormGroup;
  expertForm: FormGroup;

  constructor(private fb: FormBuilder, private registrationService: RegistrationService) {
    this.innovatorForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
    });

    this.expertForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      skills: ['', Validators.required],
      rating: ['', Validators.required],
      budget: ['', Validators.required],
    });
  }

  // innovator: any = {};
  // expert: any = {};

  // constructor(private registrationService: RegistrationService) {}


  registerInnovator() {
    console.log('In Com ' + JSON.stringify(this.innovatorForm.value));
    // RegistrationService to handle HTTP requests
    this.registrationService.registerInnovator(this.innovatorForm.value).subscribe(
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
    console.log('In Com ' + JSON.stringify(this.expertForm.value));
    // RegistrationService to handle HTTP requests
    this.registrationService.registerExpert(this.expertForm.value).subscribe(
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





