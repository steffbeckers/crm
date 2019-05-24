import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AccountsListComponent } from './accounts.list.component';
import { AccountsListGuard } from './accounts.list.guard';
import { AccountComponent } from './account.details.component';
import { AccountGuard } from './account.details.guard';
import { NewAccountComponent } from './account.new.component';
import { NewAccountGuard } from './account.new.guard';
import { EditAccountComponent } from './account.edit.component';
import { EditAccountGuard } from './account.edit.guard';

/**
 * Adjust module routing here.
 */
const routes: Routes = [
  {
    path: '',
    component: AccountsListComponent,
    canActivate: [AccountsListGuard],
    resolve: {
      accounts: AccountsListGuard,
    },
  },
  {
    path: 'new',
    component: NewAccountComponent,
    canActivate: [NewAccountGuard],
  },
  {
    path: ':id/edit',
    component: EditAccountComponent,
    canActivate: [EditAccountGuard],
    resolve: {
      account: EditAccountGuard,
    },
  },
  {
    path: ':id',
    component: AccountComponent,
    canActivate: [AccountGuard],
    resolve: {
      account: AccountGuard,
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountsRoutingModule {}
