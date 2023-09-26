import { Component, OnInit  } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ExpertprofileService } from 'src/app/services/expertprofile.service';
import { Expert } from 'src/models/expert';

@Component({
  selector: 'app-expertprofile',
  templateUrl: './expertprofile.component.html',
  styleUrls: ['./expertprofile.component.css']
})
export class ExpertprofileComponent implements OnInit {
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  // ExpertID: string ;
  // expertProfileForm: FormGroup ;
  // expertProfile: Expert ;

  // constructor(
  //   private route: ActivatedRoute,
  //   private formBuilder: FormBuilder,
  //   private expertprofileService: ExpertprofileService
  // ) {
  //   this.expertProfileForm = this.formBuilder.group({
  //     // Define your form controls here to update the expert profile data
  //   });
  // }

  // ngOnInit(): void {
  //   this.route.params.subscribe(params => {
  //     this.ExpertID = params['id'];
  //     this.getUserProfile();
  //   });
  // }

  // getUserProfile() {
  //   this.expertprofileService.getUserProfile(this.ExpertID).subscribe((data: Expert) => {
  //     this.expertProfile = data;
  //     // Populate the form controls with expert profile data
  //     this.expertProfileForm.patchValue({
  //       // Map expert profile properties to form controls
  //       // Example: name: data.name, email: data.email, etc.
  //     });
  //   });
  // }

  // updateUserProfile() {
  //   const updatedProfile = this.expertProfileForm.value;
  //   this.expertprofileService.updateUserProfile(this.ExpertID, updatedProfile).subscribe((data: Expert) => {
  //     this.expertProfile = data;
  //     // Handle successful update
  //   });
  // }
}
