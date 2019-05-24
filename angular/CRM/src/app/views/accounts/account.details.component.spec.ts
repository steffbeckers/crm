import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { By } from '@angular/platform-browser';

import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs/internal/observable/of';

import { AccountComponent } from './account.details.component';
import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

describe('AccountComponent', () => {
  let component: AccountComponent;
  let fixture: ComponentFixture<AccountComponent>;
  let service;
  let spy;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              data: {
                account: new Account(),
              },
            },
          },
        },
        AccountsService,
      ],
      declarations: [AccountComponent],
      imports: [RouterTestingModule, HttpClientTestingModule],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    // add spies!
    service = fixture.debugElement.injector.get(AccountsService);
    spy = spyOn(service, 'destroy').and.returnValue(of(true));
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
    expect(component.selectedAccount).not.toBeUndefined();
  });

  describe('onDestroy', () => {
    it('should redirect to list view on success', () => {
      spy = service.destroy.and.returnValue(of(true));
      component.onDestroy();
      expect(spy.calls.any()).toBe(true, 'destroy called');
      fixture.whenStable().then(() => {
        fixture.detectChanges();
        const de = fixture.debugElement.query(By.css('title'));
        const el = de.nativeElement;
        expect(el.textContent()).toBe('Accounts List');
      });
    });

    it('should do nothing on failure', () => {
      spy = service.destroy.and.returnValue(of(true));
      component.onDestroy();
      expect(spy.calls.any()).toBe(true, 'destroy called');
      fixture.whenStable().then(() => {
        fixture.detectChanges();
        const de = fixture.debugElement.query(By.css('title'));
        const el = de.nativeElement;
        expect(el.textContent()).toBe('Accounts Details');
      });
    });
  });
});
