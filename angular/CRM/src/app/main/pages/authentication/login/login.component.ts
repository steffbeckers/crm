import { Component, OnInit, OnDestroy, ViewEncapsulation, ElementRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { environment } from 'environments/environment';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';

import { AuthService } from 'app/services/auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: fuseAnimations,
})
export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;
  @ViewChild('emailOrUsernameField') emailOrUsernameField: ElementRef;
  @ViewChild('passwordField') passwordField: ElementRef;

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
    public auth: AuthService,
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
    this.loginForm = this._formBuilder.group({
      emailOrUsername: ['', Validators.required],
      password: ['', Validators.required],
      rememberMe: [true],
    });

    // Retrieve from URL query params
    const email = this.route.snapshot.queryParams.email;
    if (email) {
      this.loginForm.patchValue({ emailOrUsername: email });
    }
    const username = this.route.snapshot.queryParams.username;
    if (username) {
      this.loginForm.patchValue({ emailOrUsername: username });
    }
    const message = this.route.snapshot.queryParams.message;
    if (message) {
      if (message === 'password-reset-success') {
        // TODO: Translate
        this._snackBar.open('Your password has been reset successfully. You can login now.', 'Close', { duration: 5000 });
      }
    }

    // Remove query params
    this.router.navigate([], {
      queryParams: {
        email: null,
        username: null,
        message: null,
      },
      queryParamsHandling: 'merge',
    });

    // Autofocus
    if (!email) {
      this.emailOrUsernameField.nativeElement.focus();
    } else {
      this.passwordField.nativeElement.focus();
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

  login(): void {
    // Reset snackbar
    this._snackBar.dismiss();

    // Validate
    if (this.loginForm.invalid) {
      return;
    }

    this.http.post(environment.api + '/auth/login', this.loginForm.value).subscribe(
      (authenticated: any) => {
        this.auth.login(authenticated);

        // Routing after login
        const returnUrl = this.route.snapshot.queryParams.returnUrl;
        if (returnUrl) {
          this.router.navigateByUrl(returnUrl);
        } else {
          this.router.navigateByUrl('/apps/dashboards/analytics');
        }
      },
      (error: any) => {
        if (error.error === 'invalid') {
          // TODO: Translate
          this._snackBar.open('The user name or password is incorrect.', 'Close');
          // Clear password
          this.loginForm.patchValue({ password: '' });
          // Focus
          this.passwordField.nativeElement.focus();
        }

        if (error.error === 'locked-out') {
          // TODO: Translate
          this._snackBar.open('Your account is locked. Please try again later.', 'Close');
        }

        if (error.error === 'not-allowed') {
          // TODO: Translate
          this._snackBar.open('You are not allowed to login.', 'Close');
        }
      }
    );
  }
}
