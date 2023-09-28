import { Component } from '@angular/core';
import { ProjectserviceService } from 'src/app/services/projectservice.service';
import { Project } from 'src/models/project';
import { ProposalDialogComponent } from '../proposal-dialog/proposal-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-innovator-my-projects',
  templateUrl: './innovator-my-projects.component.html',
  styleUrls: ['./innovator-my-projects.component.css']
})
export class InnovatorMyProjectsComponent {
  projects:Project[]=[]

  constructor(public dialog: MatDialog, private _projectService: ProjectserviceService) {}

  ngOnInit() {
    this.getProjectsByInnovatorId();
  }

  getProjectsByInnovatorId() {
    this._projectService.getInnovatorProjects().subscribe((data: Project[]) => {
      this.projects = data;
    });
  }

  openProposalDialog(project: any) {
    this.dialog.open(ProposalDialogComponent, {
      data: { project }
    });
  }


  showProposalPopup = false;
  selectedProject: any;
  proposals: any[] = [];
  proposalAccepted = false;

  editProject(projectId: any) {
    // Implement the edit functionality
  }

  deleteProject(projectId: any) {
    // Implement the delete functionality
  }

  viewProposals(project: any) {
    this.selectedProject = project;
    // Fetch proposals by project ID using a service
    // Assign the proposals to this.proposals
    // Set proposalAccepted based on whether a proposal has already been accepted
    this.showProposalPopup = true;
  }

  acceptProposal(proposalId: any) {
    // Implement logic to accept a proposal and disable other proposal buttons
    this.proposalAccepted = true;
  }

  closeProposalPopup() {
    this.showProposalPopup = false;
  }
  
}
