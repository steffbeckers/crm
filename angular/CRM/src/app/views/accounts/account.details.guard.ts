import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';

import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

@Injectable()
/**
 * Show View guard for view access and data preloading.
 */
export class AccountGuard implements CanActivate, Resolve<Account> {
  /**
   * Component constructor and DI injection point.
   * @param {AccountsService} service
   */
  constructor(private service: AccountsService) {}

  /**
   * Method to determine if we can activate the view based on custom logic.
   * @param {ActivatedRouteSnapshot} next
   * @param {RouterStateSnapshot} state
   * @returns {Observable<boolean> | Promise<boolean> | boolean}
   */
  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }

  /**
   * Preloads data prior to activating view. Loaded data is accessible to component.
   * @param {ActivatedRouteSnapshot} route
   * @param {RouterStateSnapshot} state
   * @returns {Observable<Account> | Promise<Account>}
   */
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Account> | Promise<Account> {
    const id = route.paramMap.get('id');
    return this.service.show(id);
  }
}
