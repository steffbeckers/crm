import { Component, Injector } from '@angular/core';
import { AddAccountGenerated } from './add-account-generated.component';

@Component({
  selector: 'page-add-account',
  templateUrl: './add-account.component.html'
})
export class AddAccountComponent extends AddAccountGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
