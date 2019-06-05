import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { MatButtonModule, MatIconModule, MatSnackBarModule } from '@angular/material';
import { TranslateModule } from '@ngx-translate/core';
import 'hammerjs';

// Fake DB
import { FakeDbService } from 'app/fake-db/fake-db.service';

// Fuse theme
import { FuseModule } from '@fuse/fuse.module';
import { FuseSharedModule } from '@fuse/shared.module';
import { FuseProgressBarModule, FuseSidebarModule, FuseThemeOptionsModule } from '@fuse/components';
import { fuseConfig } from 'app/fuse-config';

// Components
import { AppComponent } from 'app/app.component';

// Modules
import { LayoutModule } from 'app/layout/layout.module';
import { SampleModule } from 'app/main/sample/sample.module';
import { PagesModule } from './main/pages/pages.module';

// Interceptors
import { LogInterceptor } from './interceptors/log.interceptor';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';

// Guards
import { IsAuthenticatedGuard } from './guards/auth.guard';

// Fake DB
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';

// Helpers
import { Logger } from './helpers/logger';

const appRoutes: Routes = [
  {
    path: 'apps',
    loadChildren: './main/apps/apps.module#AppsModule',
    canActivate: [IsAuthenticatedGuard],
  },
  {
    path: '',
    loadChildren: './main/pages/pages.module#PagesModule',
    canActivate: [IsAuthenticatedGuard],
  },
  {
    path: '**',
    redirectTo: 'apps/dashboards/analytics',
  },
];

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),

    TranslateModule.forRoot(),
    InMemoryWebApiModule.forRoot(FakeDbService, {
      delay: 0,
      passThruUnknownUrl: true,
    }),

    // Material moment date module
    MatMomentDateModule,

    // Material
    MatButtonModule,
    MatIconModule,
    MatSnackBarModule,

    // Fuse modules
    FuseModule.forRoot(fuseConfig),
    FuseProgressBarModule,
    FuseSharedModule,
    FuseSidebarModule,
    FuseThemeOptionsModule,

    // App modules
    LayoutModule,
    SampleModule,
    PagesModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LogInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true,
    },
    Logger,
    IsAuthenticatedGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
