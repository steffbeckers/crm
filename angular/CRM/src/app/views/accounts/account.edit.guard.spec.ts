import { TestBed, async, inject } from '@angular/core/testing';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { EditAccountGuard } from './account.edit.guard';
import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

describe('EditAccountGuard', () => {
  beforeEach(() => {
    // mocks!
    const serviceStub = {
      show: (value) => {
        return Promise.resolve(new Account());
      },
    };
    // set testbed
    TestBed.configureTestingModule({
      providers: [EditAccountGuard, { provide: AccountsService, useValue: serviceStub }],
    });
  });

  it('should ...', inject([EditAccountGuard], (guard: EditAccountGuard) => {
    expect(guard).toBeTruthy();
  }));

  it('should return true for canActivate', inject([EditAccountGuard], (guard: EditAccountGuard) => {
    expect(guard.canActivate(null, null)).toBeTruthy();
  }));

  it('should return value for resolve', inject([EditAccountGuard], (guard: EditAccountGuard) => {
    const route: ActivatedRouteSnapshot = new ActivatedRouteSnapshot();
    route.params = {
      id: 1,
    };
    expect(guard.resolve(route, null)).not.toBeUndefined();
  }));
});
