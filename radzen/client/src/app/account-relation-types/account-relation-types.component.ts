import { Component, Injector } from '@angular/core';
import { AccountRelationTypesGenerated } from './account-relation-types-generated.component';

@Component({
  selector: 'page-account-relation-types',
  templateUrl: './account-relation-types.component.html'
})
export class AccountRelationTypesComponent extends AccountRelationTypesGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
