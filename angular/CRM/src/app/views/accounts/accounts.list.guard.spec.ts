import { TestBed, async, inject } from '@angular/core/testing';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AccountsListGuard } from './accounts.list.guard';
import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

describe('AccountsListGuard', () => {
  beforeEach(() => {
    // mocks!
    const serviceStub = {
      list: (value) => {
        return Promise.resolve([new Account()]);
      },
    };
    // set testbed
    TestBed.configureTestingModule({
      providers: [AccountsListGuard, { provide: AccountsService, useValue: serviceStub }],
    });
  });

  it('should ...', inject([AccountsListGuard], (guard: AccountsListGuard) => {
    expect(guard).toBeTruthy();
  }));

  it('should return true for canActivate', inject([AccountsListGuard], (guard: AccountsListGuard) => {
    expect(guard.canActivate(null, null)).toBeTruthy();
  }));

  it('should return value for resolve', inject([AccountsListGuard], (guard: AccountsListGuard) => {
    const route: ActivatedRouteSnapshot = new ActivatedRouteSnapshot();
    expect(guard.resolve(null, null)).not.toBeUndefined();
  }));
});
