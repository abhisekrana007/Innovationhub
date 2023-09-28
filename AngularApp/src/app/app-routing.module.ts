import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoPreloading, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { InnovatorprojecthomeComponent } from './components/innovatorprojecthome/innovatorprojecthome.component';
import { ProposalhomeComponent } from './components/proposalhome/proposalhome.component';
import { InnovatorprojectComponent } from './components/innovatorproject/innovatorproject.component';
import { ExpertproposalComponent } from './components/expertproposal/expertproposal.component';
import { authenticateGuard } from './guards/authenticate.guard';
import { InnovatorMyProjectsComponent } from './components/innovator-my-projects/innovator-my-projects.component';


const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'registration', component:RegistrationComponent},
  {path:'', component:DashboardComponent},
  {path:'innovator/home', component:InnovatorprojecthomeComponent,canActivate:[authenticateGuard]},
  {path:'expert/home', component:ProposalhomeComponent,canActivate:[authenticateGuard]},
  {path:'expert/myproposals', component:ExpertproposalComponent,canActivate:[authenticateGuard]},
  {path:'innovator/myprojects', component:InnovatorMyProjectsComponent,canActivate:[authenticateGuard]},
  
  // { path: '', redirectTo: '/dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


export const components = [LoginComponent,RegistrationComponent,DashboardComponent]

