import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule, components } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatToolbarModule} from '@angular/material/toolbar';
import { FormsModule } from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';

import { LoginService } from './services/login.service';

import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatCardModule} from '@angular/material/card'; 
import {MatFormFieldModule } from '@angular/material/form-field';
import {MatTabsModule} from '@angular/material/tabs';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { ErrorCatchingInterceptor } from './interceptor/error-catching.interceptor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RegistrationService } from './services/registration.service';
import { RegistrationComponent } from './components/registration/registration.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MatMenuModule } from '@angular/material/menu';
import { InnovatorprofileComponent } from './components/innovatorprofile/innovatorprofile.component';
import { ExpertprofileComponent } from './components/expertprofile/expertprofile.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ModalComponent } from './components/modal/modal.component';
import { CardComponent } from './components/card/card.component';
import { InnovatorprojectComponent } from './components/innovatorproject/innovatorproject.component';
import { ProposalhomeComponent } from './components/proposalhome/proposalhome.component';
import { CardhomeComponent } from './components/cardhome/cardhome.component';
import { ModalhomeComponent } from './components/modalhome/modalhome.component';
import { InnovatorprojecthomeComponent } from './components/innovatorprojecthome/innovatorprojecthome.component';
import { ExpertproposalComponent } from './components/expertproposal/expertproposal.component';
import { ModalinovhomeComponent } from './components/modalinovhome/modalinovhome.component';
import { ModalexpertproposalComponent } from './components/modalexpertproposal/modalexpertproposal.component';
import { CardinovhomeComponent } from './components/cardinovhome/cardinovhome.component';
import { CardexpertproposalComponent } from './components/cardexpertproposal/cardexpertproposal.component';
import { DecodeJWTService } from './services/decode-jwt.service';
import { InnovatorMyProjectsComponent } from './components/innovator-my-projects/innovator-my-projects.component';
import { ProposalDialogComponent } from './components/proposal-dialog/proposal-dialog.component';
import {MatDialogModule} from '@angular/material/dialog';
import { ExpertDialogComponent } from './components/expert-dialog/expert-dialog.component';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    components,
    DashboardComponent,
    InnovatorprofileComponent,
    ExpertprofileComponent,
    NavbarComponent,
  
    ModalComponent,
    CardComponent,
    InnovatorprojectComponent,
    ProposalhomeComponent,
    CardhomeComponent,
    ModalhomeComponent,
    InnovatorprojecthomeComponent,
    ExpertproposalComponent,
    ModalinovhomeComponent,
    ModalexpertproposalComponent,
    CardinovhomeComponent,
    CardexpertproposalComponent,
    InnovatorMyProjectsComponent,    
    ProposalDialogComponent, ExpertDialogComponent

  ],
  imports: [
    BrowserModule,BrowserAnimationsModule,MatExpansionModule,
    MatToolbarModule,FormsModule,HttpClientModule,MatSlideToggleModule,
    MatButtonModule,MatIconModule,MatDividerModule,MatCardModule,MatFormFieldModule,
    ReactiveFormsModule,AppRoutingModule,MatTabsModule,MatInputModule,MatMenuModule,
    NgbModule,MatDialogModule
    
  ],
  providers: [LoginService,RegistrationService,DecodeJWTService,
    {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorCatchingInterceptor,
    multi: true
}
],

  bootstrap: [AppComponent]
})
export class AppModule { }
