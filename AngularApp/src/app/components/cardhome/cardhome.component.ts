import { Component } from '@angular/core';
import { ProjectserviceService } from 'src/app/services/projectservice.service';
import { Project } from 'src/models/project';

@Component({
  selector: 'app-cardhome',
  templateUrl: './cardhome.component.html',
  styleUrls: ['./cardhome.component.css']
})
export class CardhomeComponent {

  projects:Project[]=[]

 

constructor(private _projectService: ProjectserviceService) {}

 

ngOnInit() {
  this.getProjects();
}

 

getProjects() {
  this._projectService.getAllProjects().subscribe((data: Project[]) => {
    this.projects = data;
    console.log(this.projects);
  });
}


}
