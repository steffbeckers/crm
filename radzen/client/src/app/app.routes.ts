import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { AccountsComponent } from './accounts/accounts.component';
import { AddAccountComponent } from './add-account/add-account.component';
import { EditAccountComponent } from './edit-account/edit-account.component';
import { AccountRelationTypesComponent } from './account-relation-types/account-relation-types.component';
import { AddAccountRelationTypeComponent } from './add-account-relation-type/add-account-relation-type.component';
import { EditAccountRelationTypeComponent } from './edit-account-relation-type/edit-account-relation-type.component';
import { AddressesComponent } from './addresses/addresses.component';
import { AddAddressComponent } from './add-address/add-address.component';
import { EditAddressComponent } from './edit-address/edit-address.component';
import { ContactsComponent } from './contacts/contacts.component';
import { AddContactComponent } from './add-contact/add-contact.component';
import { EditContactComponent } from './edit-contact/edit-contact.component';
import { CountriesComponent } from './countries/countries.component';
import { AddCountryComponent } from './add-country/add-country.component';
import { EditCountryComponent } from './edit-country/edit-country.component';
import { LoginComponent } from './login/login.component';
import { ApplicationUsersComponent } from './application-users/application-users.component';
import { ApplicationRolesComponent } from './application-roles/application-roles.component';
import { RegisterApplicationUserComponent } from './register-application-user/register-application-user.component';
import { AddApplicationRoleComponent } from './add-application-role/add-application-role.component';
import { EditApplicationUserComponent } from './edit-application-user/edit-application-user.component';
import { AddApplicationUserComponent } from './add-application-user/add-application-user.component';
import { ProfileComponent } from './profile/profile.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

import { SecurityService } from './security.service';
import { AuthGuard } from './auth.guard';
export const routes: Routes = [
  { path: '', redirectTo: '/accounts', pathMatch: 'full' },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'accounts',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AccountsComponent
      },
      {
        path: 'add-account',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddAccountComponent
      },
      {
        path: 'edit-account/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditAccountComponent
      },
      {
        path: 'account-relation-types',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AccountRelationTypesComponent
      },
      {
        path: 'add-account-relation-type',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddAccountRelationTypeComponent
      },
      {
        path: 'edit-account-relation-type/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditAccountRelationTypeComponent
      },
      {
        path: 'addresses',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddressesComponent
      },
      {
        path: 'add-address',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddAddressComponent
      },
      {
        path: 'edit-address/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditAddressComponent
      },
      {
        path: 'contacts',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ContactsComponent
      },
      {
        path: 'add-contact',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddContactComponent
      },
      {
        path: 'edit-contact/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditContactComponent
      },
      {
        path: 'countries',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: CountriesComponent
      },
      {
        path: 'add-country',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddCountryComponent
      },
      {
        path: 'edit-country/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditCountryComponent
      },
      {
        path: 'application-users',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ApplicationUsersComponent
      },
      {
        path: 'application-roles',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ApplicationRolesComponent
      },
      {
        path: 'register-application-user',
        data: {
          roles: ['Everybody'],
        },
        component: RegisterApplicationUserComponent
      },
      {
        path: 'add-application-role',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddApplicationRoleComponent
      },
      {
        path: 'edit-application-user/:Id',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: EditApplicationUserComponent
      },
      {
        path: 'add-application-user',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: AddApplicationUserComponent
      },
      {
        path: 'profile',
        canActivate: [AuthGuard],
        data: {
          roles: ['Authenticated'],
        },
        component: ProfileComponent
      },
      {
        path: 'unauthorized',
        data: {
          roles: ['Everybody'],
        },
        component: UnauthorizedComponent
      },
    ]
  },
  {
    path: '',
    component: LoginLayoutComponent,
    children: [
      {
        path: 'login',
        data: {
          roles: ['Everybody'],
        },
        component: LoginComponent
      },
    ]
  },
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
