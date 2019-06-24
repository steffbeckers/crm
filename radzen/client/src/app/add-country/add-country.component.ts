import { Component, Injector } from '@angular/core';
import { AddCountryGenerated } from './add-country-generated.component';

@Component({
  selector: 'page-add-country',
  templateUrl: './add-country.component.html'
})
export class AddCountryComponent extends AddCountryGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
