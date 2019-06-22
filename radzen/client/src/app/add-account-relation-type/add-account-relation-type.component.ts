import { Component, Injector } from '@angular/core';
import { AddAccountRelationTypeGenerated } from './add-account-relation-type-generated.component';

@Component({
  selector: 'page-add-account-relation-type',
  templateUrl: './add-account-relation-type.component.html'
})
export class AddAccountRelationTypeComponent extends AddAccountRelationTypeGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
