import { Component,Input } from '@angular/core';
import { RoutingService } from 'src/app/services/routing.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  @Input() role: any;

  constructor(private _routingservice : RoutingService) {
  }

  logout(){
    localStorage.clear();
    this._routingservice.toLogin();
  }
}
