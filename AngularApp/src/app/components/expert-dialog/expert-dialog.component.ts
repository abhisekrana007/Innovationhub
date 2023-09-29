import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ExpertprofileService } from 'src/app/services/expertprofile.service';
import { Expert } from 'src/models/expert';
import { Project } from 'src/models/project';

@Component({
  selector: 'app-expert-dialog',
  templateUrl: './expert-dialog.component.html',
  styleUrls: ['./expert-dialog.component.css']
})
export class ExpertDialogComponent {
  project: Project;
  expert : any;

  constructor(
    public dialogRef: MatDialogRef<ExpertDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private _expertservice : ExpertprofileService
  ) {
    this.project = data.project;
  }

  ngOnInit() {
    this.getProposalsByProjectId(this.project);
  }

  getProposalsByProjectId(project : Project) {
    this._expertservice.getExpertByExpertId(project).subscribe((data: Expert) => {
      this.expert = data;
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
