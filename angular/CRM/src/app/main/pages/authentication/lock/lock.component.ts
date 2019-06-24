import { Component, OnInit, ViewEncapsulation, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';

import { AuthService } from 'app/services/auth.service';

@Component({
  selector: 'lock',
  templateUrl: './lock.component.html',
  styleUrls: ['./lock.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: fuseAnimations,
})
export class LockComponent implements OnInit, OnDestroy {
  lockForm: FormGroup;

  /**
   * Constructor
   *
   * @param {FuseConfigService} _fuseConfigService
   * @param {FormBuilder} _formBuilder
   */
  constructor(private _fuseConfigService: FuseConfigService, private _formBuilder: FormBuilder, private authService: AuthService) {
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
    this.lockForm = this._formBuilder.group({
      username: [
        {
          value: this.authService.user.username,
          disabled: true,
        },
        Validators.required,
      ],
      password: ['', Validators.required],
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
}
