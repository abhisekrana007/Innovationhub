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
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTabsModule} from '@angular/material/tabs';
import { ReactiveFormsModule } from '@angular/forms';

import { ErrorCatchingInterceptor } from './interceptor/error-catching.interceptor';

import { RegistrationService } from './services/registration.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
<<<<<<< HEAD

   

=======
    components
>>>>>>> dab1542965d02f6f8cda7029bae4a639344f359a
  ],
  imports: [
    BrowserModule,BrowserAnimationsModule,MatExpansionModule,
    MatToolbarModule,FormsModule,HttpClientModule,MatSlideToggleModule,
    MatButtonModule,MatIconModule,MatDividerModule,MatCardModule,MatFormFieldModule,
    ReactiveFormsModule,AppRoutingModule,MatTabsModule

  ],
  providers: [LoginService,RegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
