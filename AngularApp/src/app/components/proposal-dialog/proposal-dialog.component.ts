import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ProposalserviceService } from 'src/app/services/proposalservice.service';
import { Project } from 'src/models/project';
import { Proposal } from 'src/models/proposal';
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-proposal-dialog',
  templateUrl: './proposal-dialog.component.html',
  styleUrls: ['./proposal-dialog.component.css']
})
export class ProposalDialogComponent {
  project: Project;
  proposals : Proposal[]=[];

  constructor(
    public dialogRef: MatDialogRef<ProposalDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private _proposalservice : ProposalserviceService
  ) {
    this.project = data.project;
  }

  ngOnInit() {
    this.getProposalsByProjectId(this.project);
  }

  getProposalsByProjectId(project : Project) {
    this._proposalservice.getProposalsByProjectId(project).subscribe((data: Proposal[]) => {
      this.proposals = data;
    });
  }

  acceptProposal(proposalId: any) {
    // Implement logic to accept a proposal
    // You can send an API request to update the proposal status, for example
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
