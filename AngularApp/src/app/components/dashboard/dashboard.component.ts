import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private router: Router) { }
  logout() {
    // Implement logout logic here
    // Example: Clear user session, navigate to login page, etc.
    this.router.navigate(['/login']);
  }

  ngOnInit(): void {
  }

}
