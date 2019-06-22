/*
  This file is automatically generated. Any changes will be overwritten.
  Modify profile.component.ts instead.
*/
import { LOCALE_ID, ChangeDetectorRef, ViewChild, AfterViewInit, Injector, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Subscription } from 'rxjs';

import { DialogService, DIALOG_PARAMETERS, DialogRef } from '@radzen/angular/dist/dialog';
import { NotificationService } from '@radzen/angular/dist/notification';
import { ContentComponent } from '@radzen/angular/dist/content';
import { HeadingComponent } from '@radzen/angular/dist/heading';
import { TemplateFormComponent } from '@radzen/angular/dist/template-form';
import { LabelComponent } from '@radzen/angular/dist/label';
import { PasswordComponent } from '@radzen/angular/dist/password';
import { RequiredValidatorComponent } from '@radzen/angular/dist/required-validator';
import { ButtonComponent } from '@radzen/angular/dist/button';

import { ConfigService } from '../config.service';

import { SecurityService } from '../security.service';

export class ProfileGenerated implements AfterViewInit, OnInit, OnDestroy {
  // Components
  @ViewChild('content1') content1: ContentComponent;
  @ViewChild('pageTitle') pageTitle: HeadingComponent;
  @ViewChild('form0') form0: TemplateFormComponent;
  @ViewChild('label1') label1: LabelComponent;
  @ViewChild('OldPassword') oldPassword: PasswordComponent;
  @ViewChild('OldPasswordRequiredValidator') oldPasswordRequiredValidator: RequiredValidatorComponent;
  @ViewChild('label2') label2: LabelComponent;
  @ViewChild('NewPassword') newPassword: PasswordComponent;
  @ViewChild('NewPasswordRequiredValidator') newPasswordRequiredValidator: RequiredValidatorComponent;
  @ViewChild('label3') label3: LabelComponent;
  @ViewChild('ConfirmPassword') confirmPassword: PasswordComponent;
  @ViewChild('ConfirmPasswordRequiredValidator') confirmPasswordRequiredValidator: RequiredValidatorComponent;
  @ViewChild('button1') button1: ButtonComponent;
  @ViewChild('button2') button2: ButtonComponent;

  router: Router;

  cd: ChangeDetectorRef;

  route: ActivatedRoute;

  notificationService: NotificationService;

  configService: ConfigService;

  dialogService: DialogService;

  dialogRef: DialogRef;

  httpClient: HttpClient;

  locale: string;

  _location: Location;

  _subscription: Subscription;

  security: SecurityService;
  parameters: any;

  constructor(private injector: Injector) {
  }

  ngOnInit() {
    this.notificationService = this.injector.get(NotificationService);

    this.configService = this.injector.get(ConfigService);

    this.dialogService = this.injector.get(DialogService);

    this.dialogRef = this.injector.get(DialogRef, null);

    this.locale = this.injector.get(LOCALE_ID);

    this.router = this.injector.get(Router);

    this.cd = this.injector.get(ChangeDetectorRef);

    this._location = this.injector.get(Location);

    this.route = this.injector.get(ActivatedRoute);

    this.httpClient = this.injector.get(HttpClient);

    this.security = this.injector.get(SecurityService);
  }

  ngAfterViewInit() {
    this._subscription = this.route.params.subscribe(parameters => {
      if (this.dialogRef) {
        this.parameters = this.injector.get(DIALOG_PARAMETERS);
      } else {
        this.parameters = parameters;
      }
      this.cd.detectChanges();
    });
  }

  ngOnDestroy() {
    this._subscription.unsubscribe();
  }


  form0Submit(event: any) {
    this.security.changePassword(`${event.OldPassword}`, `${event.NewPassword}`)
    .subscribe((result: any) => {
      this.notificationService.notify({ severity: "info", summary: `Success`, detail: `Password has been changed.` });
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: `Cannot change password`, detail: `${result.error.message}` });
    });
  }

  button2Click(event: any) {
    if (this.dialogRef) {
      this.dialogRef.close();
    } else {
      this._location.back();
    }
  }
}