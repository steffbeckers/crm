import { NgModule } from '@angular/core';

import { SharedModule } from 'src/app/shared/shared.module';
import { AccountsRoutingModule } from './accounts.routing.module';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AccountsListComponent } from './accounts.list.component';
import { AccountsListGuard } from './accounts.list.guard';
import { AccountComponent } from './account.details.component';
import { AccountGuard } from './account.details.guard';
import { NewAccountComponent } from './account.new.component';
import { NewAccountGuard } from './account.new.guard';
import { EditAccountComponent } from './account.edit.component';
import { EditAccountGuard } from './account.edit.guard';

import { AccountsService } from 'src/app/services/accounts/accounts.service';

@NgModule({
  declarations: [AccountsListComponent, NewAccountComponent, AccountComponent, EditAccountComponent],
  imports: [SharedModule, NgbModule, AccountsRoutingModule],
  providers: [AccountsService, AccountsListGuard, NewAccountGuard, AccountGuard, EditAccountGuard],
})
export class AccountsModule {}
