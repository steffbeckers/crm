import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { By } from '@angular/platform-browser';

import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs/internal/observable/of';

import { EditAccountComponent } from './account.edit.component';
import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

describe('EditAccountComponent', () => {
  let component: EditAccountComponent;
  let fixture: ComponentFixture<EditAccountComponent>;
  let service;
  let spy;

  beforeEach(async(() => {
    const item = new Account();
    item.id = 1;
    TestBed.configureTestingModule({
      providers: [
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: { data: { account: item } },
          },
        },
        AccountsService,
      ],
      declarations: [EditAccountComponent],
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    // add spies!
    service = fixture.debugElement.injector.get(AccountsService);
    spy = spyOn(service, 'update').and.returnValue(of(true));
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
    expect(component.selectedAccount).not.toBeUndefined();
  });

  describe('onSubmit', () => {
    it('should redirect to list view on success', () => {
      spy = service.update.and.returnValue(of(true));
      component.onSubmit();
      expect(spy.calls.any()).toBe(true, 'update called');
      fixture.whenStable().then(() => {
        fixture.detectChanges();
        const de = fixture.debugElement.query(By.css('title'));
        const el = de.nativeElement;
        expect(el.textContent()).toBe('Accounts List');
      });
    });

    it('should do nothing on failure', () => {
      spy = service.update.and.returnValue(of(true));
      component.onSubmit();
      expect(spy.calls.any()).toBe(true, 'update called');
      fixture.whenStable().then(() => {
        fixture.detectChanges();
        const de = fixture.debugElement.query(By.css('title'));
        const el = de.nativeElement;
        expect(el.textContent()).toBe('Edit Account');
      });
    });
  });
});
