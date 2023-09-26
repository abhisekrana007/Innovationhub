import { Component,OnInit } from '@angular/core';
import { FormBuilder,FormGroup } from '@angular/forms';

import { ModalService } from './modal.service';
import { Project } from 'src/models/project';


@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {
  formValue !:FormGroup;
  projectModelObj :  Project = new  Project();
  constructor(private formbuilder: FormBuilder,private _projectService: ModalService){}

  ngOnInit(): void {
    this.formValue = this.formbuilder.group({
      projectTitle:[''],
      projectDocument:[''],
      description:[''],
      requiredskills:['']


    })

  }

  
  // deleteEmployee(row : any){
  //   this._projectService.delete(row.ProjectID)
  //  .subscribe(res=>{
  //    alert(" deleted")
  //     this.get();
  //  })
  //  }

}
