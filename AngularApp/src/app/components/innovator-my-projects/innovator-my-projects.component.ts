import { Component } from '@angular/core';
import { ProjectserviceService } from 'src/app/services/projectservice.service';
import { Project } from 'src/models/project';
import { ProposalDialogComponent } from '../proposal-dialog/proposal-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ProposalserviceService } from 'src/app/services/proposalservice.service';

@Component({
  selector: 'app-innovator-my-projects',
  templateUrl: './innovator-my-projects.component.html',
  styleUrls: ['./innovator-my-projects.component.css']
})
export class InnovatorMyProjectsComponent {
  projects:Project[]=[]

  constructor(public dialog: MatDialog, private _projectService: ProjectserviceService,private _proposalservice : ProposalserviceService) {}

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

  viewProposals(project: Project) {
    this.selectedProject = project;
    // Fetch proposals by project ID using a service
    // Assign the proposals to this.proposals
    // Set proposalAccepted based on whether a proposal has already been accepted
    this.showProposalPopup = true;
  }

  updateStatusCompleted(project: Project) {    
    this._projectService.updateStatusCompleted(project).subscribe(); 
    window.location.reload();
  }

  acceptProposal(proposalId: any) {
    // Implement logic to accept a proposal and disable other proposal buttons
    this.proposalAccepted = true;
  }

  closeProposalPopup() {
    this.showProposalPopup = false;
  }
  
}
