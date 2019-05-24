import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { FormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';

import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs/internal/observable/of';

import { NewAccountComponent } from './account.new.component';
import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

describe('NewAccountComponent', () => {
  let component: NewAccountComponent;
  let fixture: ComponentFixture<NewAccountComponent>;
  let service;
  let spy;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      providers: [AccountsService],
      declarations: [NewAccountComponent],
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    // add spies!
    service = fixture.debugElement.injector.get(AccountsService);
    spy = spyOn(service, 'create').and.returnValue(of(true));
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });

  describe('onSubmit', () => {
    it('should redirect to list view on success', () => {
      spy = service.create.and.returnValue(of(true));
      component.onSubmit();
      expect(spy.calls.any()).toBe(true, 'create called');
      fixture.whenStable().then(() => {
        fixture.detectChanges();
        const de = fixture.debugElement.query(By.css('title'));
        const el = de.nativeElement;
        expect(el.textContent()).toBe('Accounts List');
      });
    });

    it('should do nothing on failure', () => {
      spy = service.create.and.returnValue(of(true));
      component.onSubmit();
      expect(spy.calls.any()).toBe(true, 'create called');
      fixture.whenStable().then(() => {
        fixture.detectChanges();
        const de = fixture.debugElement.query(By.css('title'));
        const el = de.nativeElement;
        expect(el.textContent()).toBe('Account Details');
      });
    });
  });
});
