import { Component } from '@angular/core';
import{FormBuilder,FormGroup} from '@angular/forms';
@Component({
  selector: 'app-innovatorproject',
  templateUrl: './innovatorproject.component.html',
  styleUrls: ['./innovatorproject.component.css']
})
export class InnovatorprojectComponent {
  formValue !: FormGroup;
constructor(private formbuilder: FormBuilder){}

ngOnInit(): void{}
}
