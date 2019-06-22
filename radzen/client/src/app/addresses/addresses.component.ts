import { Component, Injector } from '@angular/core';
import { AddressesGenerated } from './addresses-generated.component';

@Component({
  selector: 'page-addresses',
  templateUrl: './addresses.component.html'
})
export class AddressesComponent extends AddressesGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
