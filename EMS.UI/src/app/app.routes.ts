import { Routes } from '@angular/router';
import {DepartmentListComponent} from './components/department/department-list/department-list.component';
import {EmployeeListComponent} from './components/employee/employee-list/employee-list.component';
import {DesignationListComponent} from './components/designation/designation-list/designation-list.component';
import { EmployeeFormComponent } from './components/employee/employee-form/employee-form.component';

export const routes: Routes =
  [
      {
        path: '', redirectTo: '/employees', pathMatch: 'full',
      },
      {
        path: 'employees',
        title: 'Employees',
        component: EmployeeListComponent,
      },
      {
        path: 'add-employee',
        title: 'Add Employee',
        component: EmployeeFormComponent,
      },
      {
        path: 'departments',
        title: 'Departments',
        component: DepartmentListComponent
      },
      {
        path: 'designations',
        title: 'Designations',
        component: DesignationListComponent
      },
];
