import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../models/user';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl: string = 'https://localhost:7198/api/'; //  'https://localhost:7198/api/'
  currentUser = signal<User | null>(null);

  signin(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/signin', model).pipe(
      map(user => {
        if (user) {
          this.currentUser.set(user);
          localStorage.setItem('currentUser', JSON.stringify(user));
        }
      })
    );
  }

  signout() {
    this.currentUser.set(null);
    localStorage.removeItem('currentUser');
  }

  signup(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/signup', model).pipe(
      map(user => {
        if (user) {
          this.currentUser.set(user);
          localStorage.setItem('currentUser', JSON.stringify(user));
        }
        return user;
      })
    );
  }
}
