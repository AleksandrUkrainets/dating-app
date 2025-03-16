import { Component, inject } from '@angular/core';
import { RegisterComponent } from '../register/register.component';
import { HttpClient } from '@angular/common/http';
import { AccountService } from '../../services/account.service';
import { User } from '../../models/user';

@Component({
  standalone: true,
  selector: 'app-home',
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  registerMode: boolean = false;
  http = inject(HttpClient);
  users: any;

  toggleMode(): void {
    this.registerMode = !this.registerMode;
  }

  cancelRegister(event: boolean) {
    this.registerMode = event;
  }
  //'https://18.185.5.227:8080/api/'; //https://localhost:7198
  private getUsers(): void {
    this.http.get('https://localhost:7198/api/users').subscribe({
      next: data => (this.users = data),
      error: er => console.log(er),
      complete: () => console.log('Get users completed'),
    });
  }
}
