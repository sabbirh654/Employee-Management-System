import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-employee-form',
  imports: [RouterLink, FormsModule],
  templateUrl: './employee-form.component.html',
  standalone: true,
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent {
  value: string = 'hello'
}
