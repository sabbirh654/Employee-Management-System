import {ChangeDetectionStrategy, Component } from '@angular/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {provideNativeDateAdapter} from '@angular/material/core';
import {FormGroup, ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-attendance-form',
  standalone: true,
  imports: [MatFormFieldModule, MatDatepickerModule, MatInputModule, ReactiveFormsModule],
  providers:[provideNativeDateAdapter()],
  templateUrl: './attendance-form.component.html',
  styleUrl: './attendance-form.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AttendanceFormComponent {
  attendanceForm = new FormGroup({ });
}
