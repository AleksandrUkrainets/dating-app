import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavBarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  title = 'DatingAppClient';
  http = inject(HttpClient);
  users: any;
  private accountService = inject(AccountService);

  ngOnInit(): void {
    this.getUsers();
    this.setUser();
  }

  private getUsers(): void {
    this.http.get('https://localhost:7198/api/users').subscribe({
      next: data => (this.users = data),
      error: er => console.log(er),
      complete: () => console.log('Get users completed'),
    });
  }

  private setUser(): void {
    const userString = localStorage.getItem('currentUser');
    if (!userString) return;
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }
}
