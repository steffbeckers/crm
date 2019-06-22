import { Component, Injector } from '@angular/core';
import { AddAddressGenerated } from './add-address-generated.component';

@Component({
  selector: 'page-add-address',
  templateUrl: './add-address.component.html'
})
export class AddAddressComponent extends AddAddressGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
