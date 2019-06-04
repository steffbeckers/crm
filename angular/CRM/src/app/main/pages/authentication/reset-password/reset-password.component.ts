import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'environments/environment';

import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';

@Component({
  selector: 'reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: fuseAnimations,
})
export class ResetPasswordComponent implements OnInit, OnDestroy {
  resetPasswordForm: FormGroup;

  // Private
  private _unsubscribeAll: Subject<any>;

  constructor(
    private _fuseConfigService: FuseConfigService,
    private _formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {
    // Configure the layout
    this._fuseConfigService.config = {
      layout: {
        navbar: {
          hidden: true,
        },
        toolbar: {
          hidden: true,
        },
        // footer: {
        //   hidden: true,
        // },
        sidepanel: {
          hidden: true,
        },
      },
    };

    // Set the private defaults
    this._unsubscribeAll = new Subject();
  }

  // -----------------------------------------------------------------------------------------------------
  // @ Lifecycle hooks
  // -----------------------------------------------------------------------------------------------------

  /**
   * On init
   */
  ngOnInit(): void {
    // Retrieve from URL query params
    const id = this.route.snapshot.queryParams.id;
    const email = this.route.snapshot.queryParams.email;
    const code = this.route.snapshot.queryParams.code;

    // Remove query params
    this.router.navigate([], {
      queryParams: {
        id: null,
        code: null,
      },
      queryParamsHandling: 'merge',
    });

    // Validation
    if (!id || !email || !code) {
      this.router.navigateByUrl('/auth/forgot-password?error=password-reset-url-invalid');
      return;
    }

    // Form
    this.resetPasswordForm = this._formBuilder.group({
      id: [id, Validators.required],
      email: [{ disabled: true, value: email }, [Validators.required, Validators.email]],
      code: [code, Validators.required],
      password: ['', Validators.required],
      passwordConfirm: ['', [Validators.required, confirmPasswordValidator]],
    });

    // Update the validity of the 'passwordConfirm' field
    // when the 'password' field changes
    this.resetPasswordForm
      .get('password')
      .valueChanges.pipe(takeUntil(this._unsubscribeAll))
      .subscribe(() => {
        this.resetPasswordForm.get('passwordConfirm').updateValueAndValidity();
      });
  }

  /**
   * On destroy
   */
  ngOnDestroy(): void {
    // Unsubscribe from all subscriptions
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();

    // Configure the layout
    this._fuseConfigService.config = {
      layout: {
        navbar: {
          hidden: false,
        },
        toolbar: {
          hidden: false,
        },
        // footer: {
        //   hidden: false,
        // },
        sidepanel: {
          hidden: false,
        },
      },
    };
  }

  resetPassword(): void {
    // Validate
    if (this.resetPasswordForm.invalid) {
      return;
    }

    let body = this.resetPasswordForm.value;
    body.email = this.route.snapshot.queryParams.email;

    this.http.post(environment.api + '/auth/reset-password', body).subscribe(
      (result: any) => {
        this.router.navigateByUrl(`/auth/login?email=${body.email}&message=password-reset-success`);
      },
      (error: any) => {
        this.router.navigateByUrl(`/auth/forgot-password?error=password-reset-code-invalid`);
      }
    );
  }
}

/**
 * Confirm password validator
 *
 * @param {AbstractControl} control
 * @returns {ValidationErrors | null}
 */
export const confirmPasswordValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
  if (!control.parent || !control) {
    return null;
  }

  const password = control.parent.get('password');
  const passwordConfirm = control.parent.get('passwordConfirm');

  if (!password || !passwordConfirm) {
    return null;
  }

  if (passwordConfirm.value === '') {
    return null;
  }

  if (password.value === passwordConfirm.value) {
    return null;
  }

  return { passwordsNotMatching: true };
};
