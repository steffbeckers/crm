import { TestBed, async, inject } from '@angular/core/testing';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AccountGuard } from './account.details.guard';
import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

describe('AccountGuard', () => {
  beforeEach(() => {
    // mocks!
    const serviceStub = {
      show: (value) => {
        return Promise.resolve(new Account());
      },
    };
    // set testbed
    TestBed.configureTestingModule({
      providers: [AccountGuard, { provide: AccountsService, useValue: serviceStub }],
    });
  });

  it('should ...', inject([AccountGuard], (guard: AccountGuard) => {
    expect(guard).toBeTruthy();
  }));

  it('should return true for canActivate', inject([AccountGuard], (guard: AccountGuard) => {
    expect(guard.canActivate(null, null)).toBeTruthy();
  }));

  it('should return value for resolve', inject([AccountGuard], (guard: AccountGuard) => {
    const route: ActivatedRouteSnapshot = new ActivatedRouteSnapshot();
    route.params = {
      id: 1,
    };
    expect(guard.resolve(route, null)).not.toBeUndefined();
  }));
});
