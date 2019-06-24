import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject, throwError } from 'rxjs';

import { ConfigService } from './config.service';
import { ODataClient } from './odata-client';
import * as models from './crm.model';

@Injectable()
export class CrmService {
  odata: ODataClient;
  basePath: string;

  constructor(private http: HttpClient, private config: ConfigService) {
    this.basePath = config.get('crm');
    this.odata = new ODataClient(this.http, this.basePath, { legacy: false, withCredentials: true });
  }

  getAccounts(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Accounts`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createAccount(expand: string | null, account: models.Account | null) : Observable<any> {
    return this.odata.post(`/Accounts`, account, { expand }, ['Address', 'Account2', 'Account1', 'AccountRelationType', 'Contact', 'User', 'User1']);
  }

  deleteAccount(id: string | null) : Observable<any> {
    return this.odata.delete(`/Accounts(${encodeURIComponent(id)})`, item => !(item.Id == id));
  }

  getAccountById(expand: string | null, id: string | null) : Observable<any> {
    return this.odata.getById(`/Accounts(${encodeURIComponent(id)})`, { expand });
  }

  updateAccount(expand: string | null, id: string | null, account: models.Account | null) : Observable<any> {
    return this.odata.patch(`/Accounts(${encodeURIComponent(id)})`, account, item => item.Id == id, { expand }, ['Address','Account2','Account1','AccountRelationType','Contact','User','User1']);
  }

  getAccountRelationTypes(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/AccountRelationTypes`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createAccountRelationType(expand: string | null, accountRelationType: models.AccountRelationType | null) : Observable<any> {
    return this.odata.post(`/AccountRelationTypes`, accountRelationType, { expand }, []);
  }

  deleteAccountRelationType(id: string | null) : Observable<any> {
    return this.odata.delete(`/AccountRelationTypes(${encodeURIComponent(id)})`, item => !(item.Id == id));
  }

  getAccountRelationTypeById(expand: string | null, id: string | null) : Observable<any> {
    return this.odata.getById(`/AccountRelationTypes(${encodeURIComponent(id)})`, { expand });
  }

  updateAccountRelationType(expand: string | null, id: string | null, accountRelationType: models.AccountRelationType | null) : Observable<any> {
    return this.odata.patch(`/AccountRelationTypes(${encodeURIComponent(id)})`, accountRelationType, item => item.Id == id, { expand }, []);
  }

  getAddresses(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Addresses`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createAddress(expand: string | null, address: models.Address | null) : Observable<any> {
    return this.odata.post(`/Addresses`, address, { expand }, ['Country']);
  }

  deleteAddress(id: string | null) : Observable<any> {
    return this.odata.delete(`/Addresses(${encodeURIComponent(id)})`, item => !(item.Id == id));
  }

  getAddressById(expand: string | null, id: string | null) : Observable<any> {
    return this.odata.getById(`/Addresses(${encodeURIComponent(id)})`, { expand });
  }

  updateAddress(expand: string | null, id: string | null, address: models.Address | null) : Observable<any> {
    return this.odata.patch(`/Addresses(${encodeURIComponent(id)})`, address, item => item.Id == id, { expand }, ['Country']);
  }

  getContacts(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Contacts`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createContact(expand: string | null, contact: models.Contact | null) : Observable<any> {
    return this.odata.post(`/Contacts`, contact, { expand }, ['Account']);
  }

  deleteContact(id: string | null) : Observable<any> {
    return this.odata.delete(`/Contacts(${encodeURIComponent(id)})`, item => !(item.Id == id));
  }

  getContactById(expand: string | null, id: string | null) : Observable<any> {
    return this.odata.getById(`/Contacts(${encodeURIComponent(id)})`, { expand });
  }

  updateContact(expand: string | null, id: string | null, contact: models.Contact | null) : Observable<any> {
    return this.odata.patch(`/Contacts(${encodeURIComponent(id)})`, contact, item => item.Id == id, { expand }, ['Account']);
  }

  getCountries(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Countries`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createCountry(expand: string | null, country: models.Country | null) : Observable<any> {
    return this.odata.post(`/Countries`, country, { expand }, []);
  }

  deleteCountry(id: string | null) : Observable<any> {
    return this.odata.delete(`/Countries(${encodeURIComponent(id)})`, item => !(item.Id == id));
  }

  getCountryById(expand: string | null, id: string | null) : Observable<any> {
    return this.odata.getById(`/Countries(${encodeURIComponent(id)})`, { expand });
  }

  updateCountry(expand: string | null, id: string | null, country: models.Country | null) : Observable<any> {
    return this.odata.patch(`/Countries(${encodeURIComponent(id)})`, country, item => item.Id == id, { expand }, []);
  }

  getRoles(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Roles`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createRole(expand: string | null, role: models.Role | null) : Observable<any> {
    return this.odata.post(`/Roles`, role, { expand }, []);
  }

  deleteRole(id: string | null) : Observable<any> {
    return this.odata.delete(`/Roles('${encodeURIComponent(id)}')`, item => !(item.Id == id));
  }

  getRoleById(expand: string | null, id: string | null) : Observable<any> {
    return this.odata.getById(`/Roles('${encodeURIComponent(id)}')`, { expand });
  }

  updateRole(expand: string | null, id: string | null, role: models.Role | null) : Observable<any> {
    return this.odata.patch(`/Roles('${encodeURIComponent(id)}')`, role, item => item.Id == id, { expand }, []);
  }

  getUsers(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Users`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createUser(expand: string | null, user: models.User | null) : Observable<any> {
    return this.odata.post(`/Users`, user, { expand }, []);
  }

  deleteUser(id: string | null) : Observable<any> {
    return this.odata.delete(`/Users('${encodeURIComponent(id)}')`, item => !(item.Id == id));
  }

  getUserById(expand: string | null, id: string | null) : Observable<any> {
    return this.odata.getById(`/Users('${encodeURIComponent(id)}')`, { expand });
  }

  updateUser(expand: string | null, id: string | null, user: models.User | null) : Observable<any> {
    return this.odata.patch(`/Users('${encodeURIComponent(id)}')`, user, item => item.Id == id, { expand }, []);
  }

  getUserRoles(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/UserRoles`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createUserRole(expand: string | null, userRole: models.UserRole | null) : Observable<any> {
    return this.odata.post(`/UserRoles`, userRole, { expand }, ['User', 'Role']);
  }

  deleteUserRole(userId: string | null, roleId: string | null) : Observable<any> {
    return this.odata.delete(`/UserRoles(UserId='${encodeURIComponent(userId)}',RoleId='${encodeURIComponent(roleId)}')`, item => !(item.UserId == userId && item.RoleId == roleId));
  }

  getUserRoleByUserIdAndRoleId(userId: string | null, roleId: string | null, expand: string | null) : Observable<any> {
    return this.odata.getById(`/UserRoles(UserId='${encodeURIComponent(userId)}',RoleId='${encodeURIComponent(roleId)}')`, { expand });
  }

  updateUserRole(userId: string | null, roleId: string | null, expand: string | null, userRole: models.UserRole | null) : Observable<any> {
    return this.odata.patch(`/UserRoles(UserId='${encodeURIComponent(userId)}',RoleId='${encodeURIComponent(roleId)}')`, userRole, item => item.UserId == userId && item.RoleId == roleId, { expand }, ['User','Role']);
  }
}
