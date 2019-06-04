import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'environments/environment';

import { User } from 'app/models/User';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  token: string;
  user: User;

  constructor(private http: HttpClient, private router: Router) {
    // Defaults
    this.token = null;
    this.user = null;

    // Retrieve token
    this.getToken();

    // Retrieve user
    this.getUser();
  }

  login(authenticated: any): void {
    // Set user and token after login
    if (authenticated.rememberMe) {
      this.setToken(authenticated.token);
      this.setUser(authenticated.user);
    } else {
      this.token = authenticated.token;
      this.user = authenticated.user;
    }
  }

  me(): void {
    // Only retrieve current user from API if authenticated
    if (!this.isAuthenticated()) {
      return;
    }

    this.http.get(environment.api + '/auth/me').subscribe((user: User) => {
      this.setUser(user);
    });
  }

  logout(): void {
    // Only logout if authenticated
    if (!this.isAuthenticated()) {
      return;
    }

    this.http.get(environment.api + '/auth/logout').subscribe((response: any) => {
      // Return to login page
      this.router.navigateByUrl('/auth/login');

      // Clear local storage
      localStorage.clear();

      // Remove token and user
      this.token = null;
      this.user = null;
    });
  }

  isAuthenticated(): boolean {
    // TODO: Check token expiration
    return this.token ? true : false;
  }

  setToken(token): void {
    // Save to local storage
    localStorage.setItem('token', token);

    this.token = token;
  }

  getToken(): void {
    // Retrieve from local storage
    this.token = localStorage.getItem('token');
  }

  setUser(user): void {
    // Save to local storage as stringified JSON object
    localStorage.setItem('user', JSON.stringify(user));

    this.user = user;
  }

  getUser(): void {
    // Retrieve from local storage and parse JSON object
    const userObjStr = localStorage.getItem('user');
    if (userObjStr) {
      this.user = JSON.parse(userObjStr);
    }
  }
}
