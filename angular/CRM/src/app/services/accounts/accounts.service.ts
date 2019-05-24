import { Injectable, Optional } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

import { Account } from 'src/app/vos/account/account';

/**
 * Config class to be wired into an injector.
 * @see CoreModule#forRoot
 * @see https://angular.io/guide/dependency-injection#optional-dependencies
 */
export class AccountsServiceConfig {
  uri = '';
}

@Injectable()
/**
 * Service class.
 */
export class AccountsService {
  /**
   * Path uri.
   * @type {string}
   * @private
   */
  private _uri = 'http://localhost:5000/api';

  /**
   * Url to endpoint api.
   * @type {string}
   */
  private endpoint = '/accounts';

  /**
   * Endpoint request headers.
   * @type {HttpHeaders}
   */
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  /**
   * Component constructor and DI injection point.
   * @param {HttpClient} http
   * @param {AccountsServiceConfig} config
   */
  constructor(private http: HttpClient, @Optional() config: AccountsServiceConfig) {
    if (config) {
      this._uri = config.uri;
    }
  }

  /**
   * Pulls a list of Account objects.
   * @returns {Observable<Account[]>}
   */
  list(): Observable<Account[]> {
    return this.http.get<Account[]>(`${this._uri}${this.endpoint}`);
  }

  /**
   * Pulls a single Account object.
   * @param {number | string} id to retrieve.
   * @returns {Observable<Account>}
   */
  show(id: number | string): Observable<Account> {
    const url = `${this._uri}${this.endpoint}/${id}`;
    return this.http.get<Account>(url);
  }

  /**
   * Creates a single Account object.
   * @param {} value to create.
   * @returns {Observable<Account>}
   */
  create(value: Account): Observable<Account> {
    return this.http.post<Account>(`${this._uri}${this.endpoint}`, JSON.stringify(value), { headers: this.headers });
  }

  /**
   * Updates a single Account object.
   * @param {} value to update.
   * @returns {Observable<Account>}
   */
  update(value: Account): Observable<Account> {
    const url = `${this._uri}${this.endpoint}/${value.id}`;
    return this.http.put<Account>(url, JSON.stringify(value), { headers: this.headers });
  }

  /**
   * Destroys a single Account object.
   * @param {number | string} id to destroy.
   * @returns {Observable<void>}
   */
  destroy(id: number | string): Observable<void> {
    const url = `${this._uri}${this.endpoint}/${id}`;
    return this.http.delete<void>(url, { headers: this.headers });
  }
}
