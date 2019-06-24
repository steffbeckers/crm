import { Component, Injector } from '@angular/core';
import { EditAccountGenerated } from './edit-account-generated.component';

@Component({
  selector: 'page-edit-account',
  templateUrl: './edit-account.component.html'
})
export class EditAccountComponent extends EditAccountGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
