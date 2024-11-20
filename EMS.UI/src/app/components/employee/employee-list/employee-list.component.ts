import {Component, OnInit} from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {EmployeeService} from '../../../services/employee/employee.service';
//import { TableModule } from 'primeng/table';
import { RouterLink } from '@angular/router';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];

@Component({
  selector: 'app-employee-list',
  imports: [
    RouterLink,
    // TableModule,
  ],
  templateUrl: './employee-list.component.html',
  standalone: true,
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  dataSource = ELEMENT_DATA;
  employees: any[] = [];
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];

  constructor(private employeeService: EmployeeService) {
  }

  ngOnInit(): void {
      this.getEmployees();
  }

  getEmployees() {
    this.employeeService.getAllEmployees().subscribe((data: any) => {
      this.employees = data;
    });
  }

  onClick() {

  }

  onAddEmployee() {
    // Open Employee Form Dialog
  }

  onEditEmployee(employee: any) {
    // Open Employee Form Dialog with details
  }

  onDeleteEmployee(employee: any) {
    // Confirm and delete employee
  }
}
