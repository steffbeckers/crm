import { Component, Injector } from '@angular/core';
import { CountriesGenerated } from './countries-generated.component';

@Component({
  selector: 'page-countries',
  templateUrl: './countries.component.html'
})
export class CountriesComponent extends CountriesGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
