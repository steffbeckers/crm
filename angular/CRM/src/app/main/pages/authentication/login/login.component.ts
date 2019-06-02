import { Component, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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

  /**
   * Constructor
   *
   * @param {FuseConfigService} _fuseConfigService
   * @param {FormBuilder} _formBuilder
   */
  constructor(
    private _fuseConfigService: FuseConfigService,
    private _formBuilder: FormBuilder,
    public auth: AuthService,
    public route: ActivatedRoute
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
    // Validate
    if (this.loginForm.invalid) {
      return;
    }

    let returnUrl = this.route.snapshot.queryParams.returnUrl;
    if (returnUrl) {
      this.auth.login(this.loginForm.value, this.route.snapshot.queryParams.returnUrl);
    } else {
      this.auth.login(this.loginForm.value);
    }
  }
}
