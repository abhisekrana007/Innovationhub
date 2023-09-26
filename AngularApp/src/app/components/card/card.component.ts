import { Component } from '@angular/core';
import { Project } from 'src/models/project';
import { CardService } from './card.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent {

  projects:Project[]=[]

  constructor(private _projectService: CardService) {}

  ngOnInit() {
    this.getProjects();
  }

  getProjects() {
    this._projectService.get("33").subscribe((data: Project[]) => {
      this.projects = data;
      console.log(this.projects);
    });
  }


}
