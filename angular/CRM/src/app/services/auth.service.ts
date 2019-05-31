import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from 'app/models/User';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user: User;
  token: string;

  constructor(private http: HttpClient) {}

  login(credentials) {
    this.http.post(environment.api + '/auth/login', credentials).subscribe(
      (authenticated: any) => {
        console.log(authenticated);

        this.token = authenticated.token;
        this.user = authenticated.user;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
}
