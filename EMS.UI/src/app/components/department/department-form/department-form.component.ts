import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
    selector: 'app-department-form',
    imports: [FormsModule, RouterLink],
    templateUrl: './department-form.component.html',
    styleUrl: './department-form.component.css'
})
export class DepartmentFormComponent {

}
