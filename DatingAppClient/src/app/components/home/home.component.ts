import { Component, inject } from '@angular/core';
import { RegisterComponent } from '../register/register.component';

@Component({
  standalone: true,
  selector: 'app-home',
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  registerMode: boolean = false;

  toggleMode(): void {
    this.registerMode = !this.registerMode;
  }

  cancelRegister(event: boolean) {
    this.registerMode = event;
  }
}
