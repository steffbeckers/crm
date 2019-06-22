import { Component, Injector } from '@angular/core';
import { AccountsGenerated } from './accounts-generated.component';

@Component({
  selector: 'page-accounts',
  templateUrl: './accounts.component.html'
})
export class AccountsComponent extends AccountsGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
