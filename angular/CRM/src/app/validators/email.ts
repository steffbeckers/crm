import { AbstractControl, Validators } from '@angular/forms';

export function notRequiredEmailValidator(control: AbstractControl): { [key: string]: any } {
  if (!control.value) {
    return null;
  }
  return Validators.email(control);
}
