import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
    selector: 'app-designation-form',
    imports: [RouterLink, FormsModule],
    templateUrl: './designation-form.component.html',
    styleUrl: './designation-form.component.css'
})
export class DesignationFormComponent {

}
