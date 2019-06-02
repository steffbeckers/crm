import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlSegment } from '@angular/router';

import { AuthService } from 'app/services/auth.service';

@Injectable({ providedIn: 'root' })
export class IsAuthenticatedGuard implements CanActivate {
  constructor(private router: Router, private auth: AuthService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    // Check if current user is authenticated
    if (this.auth.isAuthenticated()) {
      return true;
    }

    // If /auth/ is in the URL then pass
    if (route.url.includes(new UrlSegment('auth', {}))) {
      return true;
    }

    // If not logged in, redirect to login page with the return url
    this.router.navigate(['/auth/login'], { queryParams: { returnUrl: state.url } });

    return false;
  }
}
