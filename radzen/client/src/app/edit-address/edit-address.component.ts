import { Component, Injector } from '@angular/core';
import { EditAddressGenerated } from './edit-address-generated.component';

@Component({
  selector: 'page-edit-address',
  templateUrl: './edit-address.component.html'
})
export class EditAddressComponent extends EditAddressGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
