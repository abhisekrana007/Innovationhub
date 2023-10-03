import { Component } from '@angular/core';
import { ProjectserviceService } from 'src/app/services/projectservice.service';
import { Project } from 'src/models/project';

@Component({
  selector: 'app-cardinovhome',
  templateUrl: './cardinovhome.component.html',
  styleUrls: ['./cardinovhome.component.css']
})
export class CardinovhomeComponent {

  projects:Project[]=[]
  project1 : Project = new Project();;
 

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

  onClick(project:Project)
  {
    this.project1=project;         
  }

}
