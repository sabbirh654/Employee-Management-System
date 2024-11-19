import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import {DesignationListComponent} from './components/designation/designation-list/designation-list.component';
import {EmployeeListComponent} from './components/employee/employee-list/employee-list.component';
import { EmployeeFormComponent } from './components/employee/employee-form/employee-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterLink,
    RouterOutlet,
    DesignationListComponent,
    EmployeeListComponent,
    EmployeeFormComponent,
    DesignationListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'EMS.UI';
}
