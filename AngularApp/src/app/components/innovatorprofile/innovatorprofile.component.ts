import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'; // Import ActivatedRoute
import { InnovatorprofileService } from 'src/app/services/innovatorprofile.service';
import { Innovator } from 'src/models/innovator';

@Component({
  selector: 'app-innovatorprofile',
  templateUrl: './innovatorprofile.component.html',
  styleUrls: ['./innovatorprofile.component.css']
})

export class InnovatorprofileComponent implements OnInit {
  InnovatorID : any | undefined; // Declare userId without hardcoding

  constructor(
    private route: ActivatedRoute, // Inject ActivatedRoute
    private innovatorProfileService: InnovatorprofileService
  ) {}

  profileData: Innovator | undefined;

  ngOnInit(): void {
    // Retrieve userId from the route parameters
    this.route.params.subscribe((params) => {
      this.InnovatorID  = +params['id']; // Assuming your route parameter is named 'id'
      this.fetchUserProfile();
    });
  }

  fetchUserProfile(): void {
    this.innovatorProfileService.getUserProfile(this.InnovatorID ).subscribe((data) => {
      this.profileData = data;
    });
  }
}


