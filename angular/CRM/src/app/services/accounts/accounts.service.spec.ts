import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { AccountsService } from './accounts.service';
import { Account } from 'src/app/vos/account/account';

describe('AccountsService', () => {
  const list: Account[] = [new Account(), new Account(), new Account()];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [AccountsService],
    });
  });

  afterEach(inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
    httpMock.verify();
  }));

  it('is created', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
    expect(service).toBeTruthy();
  }));

  describe('list', () => {
    it('returns response', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      service.list().subscribe((results: Account[]) => {
        expect(results).toEqual(list);
      });
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts`);
      expect(req.request.method).toBe('GET');
      req.flush(list);
    }));

    it('returns error', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      service.list().subscribe(
        () => {},
        (err) => {
          expect(err.error.message).toBe('error message');
        }
      );
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts`);
      expect(req.request.method).toBe('GET');
      req.error(new ErrorEvent('error', { message: 'error message' }));
    }));
  });

  describe('show', () => {
    it('return response', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      service.show(1).subscribe((results: Account) => {
        expect(results).toEqual(list[0]);
      });
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts/1`);
      expect(req.request.method).toBe('GET');
      req.flush(list[0]);
    }));

    it('return error', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      service.show(1).subscribe(
        () => {},
        (err) => {
          expect(err.error.message).toBe('error message');
        }
      );
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts/1`);
      expect(req.request.method).toBe('GET');
      req.error(new ErrorEvent('error', { message: 'error message' }));
    }));
  });

  describe('create', () => {
    it('return response', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      service.create(list[0]).subscribe((results: Account) => {
        expect(results).toEqual(list[0]);
      });
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts`);
      expect(req.request.method).toBe('POST');
      req.flush(list[0]);
    }));

    it('return error', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      service.create(list[0]).subscribe(
        () => {},
        (err) => {
          expect(err.error.message).toBe('error message');
        }
      );
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts`);
      expect(req.request.method).toBe('POST');
      req.error(new ErrorEvent('error', { message: 'error message' }));
    }));
  });

  describe('update', () => {
    it('return response', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      const item = list[0];
      item.id = 1;
      service.update(item).subscribe((results: Account) => {
        expect(results).toEqual(item);
      });
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts/1`);
      expect(req.request.method).toBe('PUT');
      req.flush(item);
    }));

    it('return error', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      const item = list[0];
      item.id = 1;
      service.update(item).subscribe(
        () => {},
        (err) => {
          expect(err.error.message).toBe('error message');
        }
      );
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts/1`);
      expect(req.request.method).toBe('PUT');
      req.error(new ErrorEvent('error', { message: 'error message' }));
    }));
  });

  describe('destroy', () => {
    it('return response', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      service.destroy(1).subscribe((results: any) => {
        expect(results).toBeNull();
      });
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts/1`);
      expect(req.request.method).toBe('DELETE');
      req.flush(null);
    }));

    it('return error', inject([AccountsService, HttpTestingController], (service: AccountsService, httpMock: HttpTestingController) => {
      service.destroy(1).subscribe(
        () => {},
        (err) => {
          expect(err.error.message).toBe('error message');
        }
      );
      const req = httpMock.expectOne(`http://localhost:5000/api/accounts/1`);
      expect(req.request.method).toBe('DELETE');
      req.error(new ErrorEvent('error', { message: 'error message' }));
    }));
  });
});
