import { TestBed, async, inject } from '@angular/core/testing';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { NewAccountGuard } from './account.new.guard';

describe('NewAccountGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NewAccountGuard],
    });
  });

  it('should ...', inject([NewAccountGuard], (guard: NewAccountGuard) => {
    expect(guard).toBeTruthy();
  }));

  it('should return true for canActivate', inject([NewAccountGuard], (guard: NewAccountGuard) => {
    expect(guard.canActivate(null, null)).toBeTruthy();
  }));
});
