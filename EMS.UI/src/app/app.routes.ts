import { Routes } from '@angular/router';
import {DepartmentListComponent} from './components/department/department-list/department-list.component';
import {EmployeeListComponent} from './components/employee/employee-list/employee-list.component';
import {DesignationListComponent} from './components/designation/designation-list/designation-list.component';
import { EmployeeFormComponent } from './components/employee/employee-form/employee-form.component';
import { DepartmentFormComponent } from './components/department/department-form/department-form.component';
import { DesignationFormComponent } from './components/designation/designation-form/designation-form.component';
import { AttendanceFormComponent } from './components/attendance/attendance-form/attendance-form.component';
import { AttendanceListComponent } from './components/attendance/attendance-list/attendance-list.component';

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
        path: 'add-department',
        title: 'Add Department',
        component: DepartmentFormComponent
      },
      {
        path: 'designations',
        title: 'Designations',
        component: DesignationListComponent
      },
      {
        path: 'add-designation',
        title: 'Add Designation',
        component: DesignationFormComponent
      },
      {
        path: 'attendances',
        title: 'Attendances',
        component: AttendanceListComponent
      },
      {
        path: 'add-attendance',
        title: 'Add Attendance',
        component: AttendanceFormComponent
      },
];
