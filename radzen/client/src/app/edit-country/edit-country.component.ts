import { Component, Injector } from '@angular/core';
import { EditCountryGenerated } from './edit-country-generated.component';

@Component({
  selector: 'page-edit-country',
  templateUrl: './edit-country.component.html'
})
export class EditCountryComponent extends EditCountryGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
