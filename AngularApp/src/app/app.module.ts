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

import { RegistrationService } from './services/registration.service';
import { RegistrationComponent } from './components/registration/registration.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MatMenuModule } from '@angular/material/menu';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    components,
    DashboardComponent,
  

  ],
  imports: [
    BrowserModule,BrowserAnimationsModule,MatExpansionModule,
    MatToolbarModule,FormsModule,HttpClientModule,MatSlideToggleModule,
    MatButtonModule,MatIconModule,MatDividerModule,MatCardModule,MatFormFieldModule,
    ReactiveFormsModule,AppRoutingModule,MatTabsModule,MatInputModule,MatMenuModule

  ],
  providers: [LoginService,RegistrationService,
    {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorCatchingInterceptor,
    multi: true
}
],

  bootstrap: [AppComponent]
})
export class AppModule { }
