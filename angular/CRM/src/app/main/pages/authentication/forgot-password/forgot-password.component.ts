import { Component, OnInit, ViewEncapsulation, OnDestroy, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'environments/environment';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';

@Component({
  selector: 'forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: fuseAnimations,
})
export class ForgotPasswordComponent implements OnInit, OnDestroy {
  forgotPasswordForm: FormGroup;
  @ViewChild('emailField') emailField: ElementRef;
  sent = false;

  /**
   * Constructor
   *
   * @param {FuseConfigService} _fuseConfigService
   * @param {FormBuilder} _formBuilder
   */
  constructor(
    private _fuseConfigService: FuseConfigService,
    private _formBuilder: FormBuilder,
    private _snackBar: MatSnackBar,
    private http: HttpClient,
    public route: ActivatedRoute,
    public router: Router
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
  }

  // -----------------------------------------------------------------------------------------------------
  // @ Lifecycle hooks
  // -----------------------------------------------------------------------------------------------------

  /**
   * On init
   */
  ngOnInit(): void {
    this.forgotPasswordForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
    });

    // Retrieve from URL query params
    const email = this.route.snapshot.queryParams.email;
    if (email) {
      this.forgotPasswordForm.patchValue({ email: email });
    }
    const error = this.route.snapshot.queryParams['error'];
    if (error) {
      if (error === 'password-reset-url-invalid') {
        // TODO: Translate
        this._snackBar.open('The password reset url is invalid. Please try again.', 'Close');
      }
      if (error === 'password-reset-code-invalid') {
        // TODO: Translate
        this._snackBar.open('This password reset code is invalid or already used.', 'Close');
      }
    }

    // Remove query params
    this.router.navigate([], {
      queryParams: {
        email: null,
        error: null,
      },
      queryParamsHandling: 'merge',
    });

    // Autofocus
    if (!email) {
      this.emailField.nativeElement.focus();
    }
  }

  /**
   * On destroy
   */
  ngOnDestroy(): void {
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

  sendEmail(): void {
    // Resets
    this._snackBar.dismiss();
    this.sent = false;

    // Validate
    if (this.forgotPasswordForm.invalid) {
      return;
    }

    this.http.post(environment.api + '/auth/forgot-password', this.forgotPasswordForm.value).subscribe(
      () => {
        this.sent = true;

        // TODO: Translation
        this._snackBar.open(`A password reset email is sent to ${this.forgotPasswordForm.value.email}.`, 'Close');
      },
      (error) => {
        if (error.error === 'email-not-found') {
          // TODO: Translation
          // TODO: This could also be shown in the email field error message
          this._snackBar.open(`A user with email ${this.forgotPasswordForm.value.email} could not be found.`, 'Close');
          // Clear email
          this.forgotPasswordForm.patchValue({ email: '' });
          // Focus
          this.emailField.nativeElement.focus();
        }
      }
    );
  }
}
