import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';

// RxJS
import { Observable } from 'rxjs';

// Services
import { AuthService } from '../services/auth.service';

@Injectable({ providedIn: 'root' })
export class TokenInterceptor implements HttpInterceptor {
  constructor(public auth: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // If user is authenticated, set token on requests
    if (this.auth.isAuthenticated()) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${this.auth.token}`,
        },
      });
    }

    return next.handle(req);
  }
}
