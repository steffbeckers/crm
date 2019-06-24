import { Component, Injector } from '@angular/core';
import { EditAccountRelationTypeGenerated } from './edit-account-relation-type-generated.component';

@Component({
  selector: 'page-edit-account-relation-type',
  templateUrl: './edit-account-relation-type.component.html'
})
export class EditAccountRelationTypeComponent extends EditAccountRelationTypeGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
