import { Component } from '@angular/core';
import { Project } from 'src/models/project';
import { CardService } from './card.service';
import { ProjectserviceService } from 'src/app/services/projectservice.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent {

  projects:Project[]=[]

  constructor(private _projectService: ProjectserviceService) {}

  ngOnInit() {
    this.getProjectsByInnovatorId();
  }

  getProjectsByInnovatorId() {
  
    this._projectService.getInnovatorProjects().subscribe((data: Project[]) => {
      this.projects = data;
      console.log(this.projects);
    });
  
  }


}
